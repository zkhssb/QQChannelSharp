using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Messages;
using QQChannelSharp.Dto.Pager;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 消息表情表态接口
    /// </summary>
    public interface IMessageReactionApi
    {
        /// <summary>
        /// 创建表情表态
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="messageId">消息ID</param>
        /// <param name="emoji">表情</param>
        /// <returns></returns>
        Task CreateMessageReactionAsync(string channelId, string messageId, Emoji emoji);

        /// <summary>
        /// 删除自己的表情表态
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="messageId">消息ID</param>
        /// <param name="emoji">表情</param>
        /// <returns></returns>
        Task DeleteOwnMessageReaction(string channelId, string messageId, Emoji emoji);

        /// <summary>
        /// 获取消息表情表态用户列表
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="messageId">消息ID</param>
        /// <param name="emoji">表情</param>
        /// <param name="pager">分页选择器</param>
        /// <returns></returns>
        Task<MessageReactionUsers> GetMessageReactionUsersAsync(string channelId, string messageId, Emoji emoji, MessageReactionPager pager);

    }
}
