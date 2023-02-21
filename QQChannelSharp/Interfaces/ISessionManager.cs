using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Sessions;

namespace QQChannelSharp.Interfaces
{
    /// <summary>
    /// 会话管理器接口
    /// </summary>
    public interface ISessionManager : IDisposable
    {
        Task StartAsync();
        Dictionary<Guid, SessionInfo> Sessions();
    }
}
