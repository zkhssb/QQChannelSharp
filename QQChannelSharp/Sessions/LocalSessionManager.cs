
using QQChannelSharp.Client;
using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Events;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Logger;
using QQChannelSharp.OpenApi;
using QQChannelSharp.Utils;
using QQChannelSharp.WebSocket;
using System.Net.WebSockets;

namespace QQChannelSharp.Sessions
{
    /// <summary>
    /// 基于管道实现的单机manager。
    /// </summary>
    public class LocalSessionManager : ISessionManager
    {
        private bool _disposed;
        /// <summary>
        /// 当前是否已停止
        /// </summary>
        private bool _closed;
        /// <summary>
        /// 接口
        /// </summary>
        private readonly IOpenApi _openApi;
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
        private readonly IAsyncEventBus _eventBus;

        private readonly CancellationTokenSource _cancellationTokenSource = new();

        /// <summary>
        /// 只读字典, 在线的Session信息
        /// </summary>
        public IReadOnlyDictionary<Guid, SessionInfo> OnlineSession =>
            _sessionTasks;

        public IAsyncEventBus EventBus
            => _eventBus;

        public IOpenApi OpenApi
            => _openApi;

        public bool Closed => _closed;

        public LocalSessionManager(ChannelBotInfo botInfo, OpenApiOptions options)
        {
            _closed = true;
            _openApi = OpenApiFactory.Create(options);
            HttpResult<WebsocketAP>? result = null;
            Task.Run(async () =>
            {
                result = await _openApi.GetWebSocketApAsync();
            }).Wait();
            if (!(result?.IsSuccess ?? false))
                throw new ArgumentException(result?.Error.Message);

            _apInfo = result!.Result;
            _botInfo = botInfo;
            _sessionChan = new(_apInfo.Shards); // 按照shards数量初始化，用于启动连接的管理
            _startInterval = SessionManagerUtils.CalcInterval(_apInfo.SessionStartLimit.MaxConcurrency); // 计算每次连接的延迟

            _sessionHandler = new SessionHandler(_sessionChan); // 构造会话处理器,用于监听_sessionChan的内容
            _sessionHandler.NeedConnect += NeedConnect; // 订阅需要连接事件
            _sessionHandler.NeedDisconnect += NeedDisconnect; // 订阅需要关闭事件

            _sessionTasks = new();

            _eventBus = new AsyncEventBus();
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
                        sessionInfo.Client.Error -= OnWebSocketError; // 注销任务
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
                wsClient.Error += OnWebSocketError;
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
                    Log.LogError("WebSocketError", $"会话: {session.Shard.ShardID} 连接时出现错误/{ex.GetType().Name}:{ex.Message}");

                    wsClient.ClientClosed -= OnWebSocketClosed;
                    wsClient.Received -= OnReceived;
                    wsClient.Error -= OnWebSocketError;
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
        private async Task OnWebSocketClosed(Session session, int code, string message)
        {
            TryRemoveTask(session); // 连接已经关闭, 首先移除任务

            // 开始处理错误码

            if (code == 4009) // 4009表示需要重连
                await _sessionChan.WriteAsync(session); // 直接丢回管道重连
            else // 否则需要判断这个错误代码是否是官方规定的不可再次重连的错误码
            {
                if (SessionManagerUtils.CanNotIdentify(code))
                {
                    Log.LogFatal("SessionManager", $"会话内部ID: {session.Guid} / 鉴权失败, 原因: {message}");
                    // 因为会话管理器是管理一个机器人的所有分片,既然这个分片鉴权失败,那自然其他分片也一样会鉴权失败,这里将关闭连接
                    Dispose();
                    return; // 不能进行鉴权,直接返回
                }

                if (SessionManagerUtils.CanNotResume(code)) // 对于不能够进行重连的session，需要清空 session id 与 seq
                {
                    Log.LogWarning("SessionManager", $"会话ID: {session.Id} / 重连失败, 原因: {message}");
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
            await _eventBus.PublishAsync(payload, session, _openApi);
        }

        private async Task OnWebSocketError(Session session, WebSocketException exception)
        {
            await EventBus.PublishWebSocketErrorAsync(session, exception, _openApi);
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
            if (!_closed) throw new InvalidOperationException("本地会话管理器已经启动!");
            _closed = false;
            _sessionHandler.Start(); // 开始监听管道
            for (int i = 0; i < _apInfo.Shards; i++) // 开始往管道里塞入初始的数据
            {
                await _sessionChan.WriteAsync(new Session()
                {
                    Guid = Guid.NewGuid(),
                    BotInfo = _botInfo,
                    Intent = EventBus.GetIntents(),
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

        public async Task StartAndWait()
        {
            if (!_closed) throw new InvalidOperationException("本地会话管理器已经启动!");
            _closed = false;
            for (int i = 0; i < _apInfo.Shards; i++) // 开始往管道里塞入初始的数据
            {
                await _sessionChan.WriteAsync(new Session()
                {
                    Guid = Guid.NewGuid(),
                    BotInfo = _botInfo,
                    Intent = EventBus.GetIntents(),
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

            // 阻塞的方式启动 (直接方法内读取管道)
            while (!_disposed)
            {
                Session session = await _sessionChan.ReadAsync(_cancellationTokenSource.Token);
                await NeedConnect(session);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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
            lock (this)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _cancellationTokenSource.Cancel();
                        _cancellationTokenSource.Dispose(); // 销毁管道令牌
                        _sessionHandler.Dispose(); // 先销毁监听器,以免关闭Session后重连
                        CloseAllSession(); // 关闭并销毁所有Session
                        _sessionChan.Dispose(); // 销毁管道
                        _eventBus.Dispose();
                        _semaphoreSlim.Dispose(); // 销毁锁
                    }

                    _closed = true;
                    _disposed = true;
                }
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
