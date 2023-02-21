using QQChannelSharp.WebSocket;

namespace QQChannelSharp.Interfaces
{
    public delegate Task SessionAsyncCallback(Session session);
    public interface ISessionHandler : IDisposable
    {
        event SessionAsyncCallback NeedConnect; // 需要连接
        event SessionAsyncCallback NeedDisconnect; // 需要关闭
        void Start();
        Task StopAsync();
    }
}
