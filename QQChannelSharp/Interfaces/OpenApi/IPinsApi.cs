using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Messages;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 精华消息接口
    /// </summary>
    public interface IPinsApi
    {
        /// <summary>
        /// 添加子频道精华消息
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="messageId">消息ID</param>
        /// <returns></returns>
        Task<HttpResult<PinsMessage>> AddPinsAsync(string channelId, string messageId);

        /// <summary>
        /// 删除子频道精华消息
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="messageId">消息ID</param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> DeletePinsAsync(string channelId, string messageId);

        /// <summary>
        /// 清除子频道全部精华消息
        /// </summary>
        /// <param name="channelId">子频道</param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> CleanPinsAsync(string channelId);

        /// <summary>
        /// 获取子频道精华消息
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <returns></returns>
        Task<HttpResult<PinsMessage>> GetPinsAsync(string channelId);
    }
}
