using QQChannelSharp.Interfaces.OpenApi;

namespace QQChannelSharp.Interfaces
{
    /// <summary>
    /// OpenApi接口
    /// </summary>
    public interface IOpenApi : IAnnouncesApi, IAPIPermissionsApi,
        IAudioApi, IChannelApi,
        IChannelPermissionsApi,
        IDirectMessageApi,
        IGuildApi, IInteractionApi,
        IMemberApi, IMessageApi,
        IMessageReactionApi,
        IMessageSettingApi,
        IPinsApi, IRoleApi,
        IScheduleApi, IUserApi,
        IWebHookApi,

        IDisposable
    {
        /// <summary>
        /// OpenApi版本
        /// </summary>
        int Version();
    }
}
