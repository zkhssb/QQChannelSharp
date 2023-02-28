using QQChannelSharp.Dto.Message;
using QQChannelSharp.Dto.Messages;
using QQChannelSharp.Dto.Pager;
using QQChannelSharp.Enumerations;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 消息API接口
    /// </summary>
    public interface IMessageApi
    {
        /// <summary>
        /// 获取消息信息
        /// </summary>
        /// <param name="channelId">频道ID</param>
        /// <param name="messageId">消息ID</param>
        Task<Message> MessageAsync(string channelId, string messageId);

        /// <summary>
        /// 获取消息列表
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="pager">页面</param>
        /// <returns></returns>
        Task<List<Message>> MessagesAsync(string channelId, MessagesPager pager);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="channelId">频道ID</param>
        /// <param name="message">消息</param>
        Task<Message> PostMessageAsync(string channelId, MessageToCreate message);

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="channelId">频道ID</param>
        /// <param name="messageId">消息ID</param>
        /// <param name="options">撤回可选项</param>
        /// <returns></returns>
        Task RetractMessageAsync(string channelId, string messageId, IEnumerable<RetractMessageOption>? options = null);

        /// <summary>
        /// 发送设置引导
        /// </summary>
        /// <param name="channelId">频道ID</param>
        /// <param name="atUserId">@用户ID列表</param>
        /// <returns></returns>
        Task<Message> PostSettingGuideAsync(string channelId, IEnumerable<string> atUserId);
    }
}
