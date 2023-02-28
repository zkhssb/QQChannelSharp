
using QQChannelSharp.Client;
using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Events;
using QQChannelSharp.Exceptions;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Utils;
using QQChannelSharp.WebSocket;
using System.Net.WebSockets;
using System.Threading;

namespace QQChannelSharp.Sessions
{
    /// <summary>
    /// 基于管道实现的单机manager。
    /// </summary>
    public class LocalSessionManager : ISessionManager
    {
        private bool _disposed;
        /// <summary>
        /// 接入点信息
        /// </summary>
        private readonly WebsocketAP _apInfo;
        /// <summary>
        /// 频道机器人信息
        /// </summary>
        private readonly ChannelBotInfo _botInfo;
        /// <summary>
        /// 会话字典,用于管理WebSocket的连接
        /// </summary>
        private readonly Dictionary<Guid, SessionInfo> _sessionTasks;
        /// <summary>
        /// 会话处理器,用于监听管道
        /// </summary>
        private readonly ISessionHandler _sessionHandler;
        /// <summary>
        /// 用于传递Session的管道
        /// </summary>
        private readonly ChanManager<Session> _sessionChan = new(1);
        /// <summary>
        /// 通过每秒最多可以创建多少连接算出来的每次连接的间隔
        /// </summary>
        private readonly TimeSpan _startInterval = TimeSpan.FromSeconds(5);
        /// <summary>
        /// 对可同时访问资源或资源池的线程数加以限制的 Semaphore 的轻量替代。
        /// </summary>
        private readonly SemaphoreSlim _semaphoreSlim = new(1);

        /// <summary>
        /// 事件总线实例
        /// </summary>
        private readonly AsyncEventBus _eventBus = new AsyncEventBus();

        /// <summary>
        /// 只读字典, 在线的Session信息
        /// </summary>
        public IReadOnlyDictionary<Guid, SessionInfo> OnlineSession =>
            _sessionTasks;

        public IAsyncEventBus EventBus
            => _eventBus;

        public LocalSessionManager(WebsocketAP ap, ChannelBotInfo botInfo)
        {
            _apInfo = ap;
            _botInfo = botInfo;
            _sessionChan = new(_apInfo.Shards); // 按照shards数量初始化，用于启动连接的管理
            _startInterval = SessionManagerUtils.CalcInterval(_apInfo.SessionStartLimit.MaxConcurrency); // 计算每次连接的延迟

            _sessionHandler = new SessionHandler(_sessionChan); // 构造会话处理器,用于监听_sessionChan的内容
            _sessionHandler.NeedConnect += NeedConnect; // 订阅需要连接事件
            _sessionHandler.NeedDisconnect += NeedDisconnect; // 订阅需要关闭事件

            _sessionTasks = new();
        }

        /// <summary>
        /// 尝试从字典中删除一个正在运行的任务
        /// </summary>
        private bool TryRemoveTask(Session session)
        {
            try
            {
                _semaphoreSlim.Wait();
                try
                {
                    if (_sessionTasks.TryGetValue(session.Guid, out var sessionInfo))
                    {
                        sessionInfo.Client.ClientClosed -= OnWebSocketClosed; // 注销任务
                        sessionInfo.Client.Received -= OnReceived; // 注销任务
                        sessionInfo.Client.Dispose(); // 销毁原来的客户端
                        _sessionTasks.Remove(session.Guid); // 从字典中删除这个任务
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return false;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        /// <summary>
        /// 尝试从字典中插入一个新的连接
        /// </summary>
        private async Task AddNewConnectAsync(Session session)
        {
            var taskInfo = await NewConnectAsync(session);
            if (null != taskInfo) // 如果在连接中出现了错误,则为null
            {
                try
                {
                    await _semaphoreSlim.WaitAsync();
                    _sessionTasks.Add(session.Guid, taskInfo); // 插入数据
                }
                finally
                {
                    _semaphoreSlim.Release();
                }
            }
        }

        /// <summary>
        /// 创建新的连接
        /// </summary>
        /// <returns>出错返回Null</returns>
        private async Task<SessionInfo?> NewConnectAsync(Session session)
        {
            try
            {
                await _semaphoreSlim.WaitAsync();
                IWebSocketClient wsClient = new WsClient(session);
                wsClient.ClientClosed += OnWebSocketClosed;
                wsClient.Received += OnReceived;
                try
                {
                    wsClient.Connect();
                    if (string.IsNullOrWhiteSpace(session.Id))
                        await wsClient.IdentifyAsync(); // sessionId为空, 尝试鉴权
                    else
                        await wsClient.ResumeAsync(); // sessionId不为空, 尝试重连
                    wsClient.Listening(); // 开始监听并处理消息
                }
                catch (WebSocketException ex)
                {
                    Console.WriteLine("shard{0} connect error: {0}", session.Shard.ShardID, ex.WebSocketErrorCode.ToString());

                    wsClient.ClientClosed -= OnWebSocketClosed;
                    wsClient.Received -= OnReceived;
                    wsClient.Dispose();
                    await _sessionChan.WriteAsync(session); // 连接失败, 丢回去重新连接
                    return null;
                }
                return new()
                {
                    Client = wsClient,
                    Session = session
                };
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        /// <summary>
        /// 当一个会话的WebSocket关闭
        /// </summary>
        private async Task OnWebSocketClosed(Session session, int code)
        {
            TryRemoveTask(session); // 连接已经关闭, 首先移除任务

            // 开始处理错误码

            if (code == 4009) // 4009表示需要重连
                await _sessionChan.WriteAsync(session); // 直接丢回管道重连
            else // 否则需要判断这个错误代码是否是官方规定的不可再次重连的错误码
            {
                if (SessionManagerUtils.CanNotIdentify(code))
                    return; // 不能进行鉴权, 这里不再处理这个session 直接返回

                if (SessionManagerUtils.CanNotResume(code)) // 对于不能够进行重连的session，需要清空 session id 与 seq
                {
                    session.Id = string.Empty;
                    session.LastSeq = 0;
                }

                await _sessionChan.WriteAsync(session); // 丢回去重新连接
            }
        }

        /// <summary>
        /// 当某个WebSocket客户端收到消息
        /// </summary>
        private async Task OnReceived(Session session, WebSocketPayload payload)
        {
            await _eventBus.PublishAsync(payload, session);
        }

        /// <summary>
        /// 需要连接CALLBACK
        /// </summary>
        private async Task NeedConnect(Session session)
        {
            // 启动新的连接前,需要先检查原来的字典中是否存在WebSocketClient
            // 如果存在,则需要先释放WebSocketClient
            TryRemoveTask(session);

            // 开始创建新的连接
            await AddNewConnectAsync(session);
            await Task.Delay(_startInterval); // 必须间隔一段时间才能创建新的连接
        }

        /// <summary>
        /// 需要断开连接CALLBACK
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        private async Task NeedDisconnect(Session session)
        {
            TryRemoveTask(session); // 从字典中移除任务 (会停止)
            await Task.CompletedTask; // 无作用
        }

        public async Task StartAsync()
        {
            _sessionHandler.Start(); // 开始监听管道
            for (int i = 0; i < _apInfo.Shards; i++) // 开始往管道里塞入初始的数据
            {
                await _sessionChan.WriteAsync(new Session()
                {
                    Guid = Guid.NewGuid(),
                    BotInfo = _botInfo,
                    Intent = _botInfo.Intents,
                    Id = string.Empty,
                    LastSeq = 0,
                    Url = _apInfo.Url,
                    Shard = new()
                    {
                        ShardID = i,
                        ShardCount = _apInfo.Shards
                    }
                }); // 如果管道已满,就会阻塞,直到管道内有剩余空间后才会继续写
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// 关闭并销毁所有Session
        /// </summary>
        private void CloseAllSession()
        {
            try
            {
                _semaphoreSlim.Wait();
                foreach (var sessionTask in _sessionTasks)
                {
                    sessionTask.Value.Client.ClientClosed -= OnWebSocketClosed;
                    sessionTask.Value.Client.Dispose();
                }
                _sessionTasks.Clear();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _sessionHandler.Dispose(); // 先销毁监听器,以免关闭Session后重连
                    CloseAllSession(); // 关闭并销毁所有Session
                    _sessionChan.Dispose(); // 销毁管道
                    _eventBus.Dispose();
                    _semaphoreSlim.Dispose(); // 销毁锁
                }

                _disposed = true;
            }
        }

        public IReadOnlyDictionary<Guid, SessionInfo> Sessions()
            => OnlineSession;

        ~LocalSessionManager()
        {
            Dispose(false);
        }
    }
}
