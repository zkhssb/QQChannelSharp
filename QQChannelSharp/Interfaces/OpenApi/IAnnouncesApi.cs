using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Announce;
using QQChannelSharp.OpenApi;
using System.Net;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 公告相关接口
    /// </summary>
    public interface IAnnouncesApi
    {
        /// <summary>
        /// 创建子频道公告
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="announce">公告信息</param>
        /// <returns></returns>
        Task<HttpResult<Announces>> CreateChannelAnnouncesAsync(string channelId, GuildAnnouncesToCreate announce);

        /// <summary>
        /// 删除子频道公告,会校验 messageId 是否匹配
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="messageId">消息ID (会判断是否为公告消息)</param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> DeleteChannelAnnouncesAsync(string channelId, string messageId);
        /// <summary>
        /// 删除子频道公告,不校验 messageId
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> CleanChannelAnnouncesAsync(string channelId);

        /// <summary>
        /// 创建频道全局公告
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="announces">公告信息</param>
        /// <returns></returns>
        Task<HttpResult<Announces>> CreateGuildAnnouncesAsync(string guildId, GuildAnnouncesToCreate announces);

        /// <summary>
        /// 删除频道全局公告
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="messageId">公告消息ID</param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> DeleteGuildAnnouncesAsync(string guildId, string messageId);

        /// <summary>
        /// 删除频道全局公告,不校验 messageId
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> CleanGuildAnnouncesAsync(string guildId);
    }
}
