using QQChannelSharp.Interfaces.OpenApi;
using RestSharp;

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
        IWebSocketApi
    {
        Task<RestResponse> SendAsync(RestRequest request);
        RestResponse Send(RestRequest request);
        /// <summary>
        /// OpenApi版本
        /// </summary>
        int Version();
    }
}
