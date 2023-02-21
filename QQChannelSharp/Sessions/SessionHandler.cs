using QQChannelSharp.Interfaces;
using QQChannelSharp.WebSocket;

namespace QQChannelSharp.Sessions
{
    /// <summary>
    /// 会话处理器, 用于创建连接
    /// </summary>
    public class SessionHandler : ISessionHandler
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly ChanManager<Session> _chanManager; // 管道管理器
        private Task? _sessionTask;

        /// <summary>
        /// Session需要连接
        /// </summary>
        public event SessionAsyncCallback? NeedConnect;

        /// <summary>
        /// Session需要销毁
        /// </summary>
        public event SessionAsyncCallback? NeedDisconnect;

        /// <summary>
        /// 死循环读取
        /// </summary>
        private async Task WhileReadAsync()
        {
            try
            {
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    // 从管道中读取session

                    var session = await _chanManager.ReadAsync(_cancellationTokenSource.Token);
                    if (null != NeedConnect)
                        await NeedConnect.Invoke(session); // 通知新的session需要连接
                }
            }
            catch (TaskCanceledException)
            {

            }
        }

        public SessionHandler(ChanManager<Session> sessions)
        {
            _chanManager = sessions;
            _cancellationTokenSource = new();
        }

        /// <summary>
        /// 开始异步处理事件
        /// </summary>
        public void Start()
        {
            if (null != _sessionTask)
                throw new InvalidOperationException(); // 任务已经启动
            _sessionTask = WhileReadAsync();
        }

        /// <summary>
        /// 停止处理异步事件
        /// </summary>
        public async Task StopAsync()
        {
            if (null != _chanManager)
            {
                while (_chanManager.ObjChannel.Reader.TryRead(out var session))
                {
                    if (null != session && null != NeedDisconnect)
                    {
                        await NeedDisconnect.Invoke(session);
                    }
                }
                _chanManager.Dispose();
            }

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();

            if (null != _sessionTask && _sessionTask.Status == TaskStatus.WaitingForActivation)
            {
                await _sessionTask; // 等待_sessionTask完成
            }
            _sessionTask?.Dispose(); // 销毁任务(如果存在的话)
        }

        public async void Dispose()
        {
            await StopAsync();
            GC.SuppressFinalize(this);
        }
    }
}
