using QQChannelSharp.Events;
using QQChannelSharp.Sessions;

namespace QQChannelSharp.Interfaces
{
    /// <summary>
    /// 会话管理器接口
    /// </summary>
    public interface ISessionManager : IDisposable
    {
        /// <summary>
        /// Api
        /// </summary>
        IOpenApi OpenApi { get; }

        /// <summary>
        /// 异步启动SessionManager (非阻塞)
        /// </summary>
        /// <returns></returns>
        Task StartAsync();

        /// <summary>
        /// 启动SessionManager (阻塞)
        /// </summary>
        /// <returns></returns>
        Task StartAndWait();
        /// <summary>
        /// 在线的Session字典
        /// <br/>
        /// <see langword="Key (Guid)"/>只在SessionManager内部维护
        /// <br/>
        /// 要获取SessionId请读<see langword="SessionInfo.Session.Id"/>
        /// </summary>
        IReadOnlyDictionary<Guid, SessionInfo> Sessions();
        /// <summary>
        /// 事件总线
        /// </summary>
        IAsyncEventBus EventBus { get; }
    }
}
