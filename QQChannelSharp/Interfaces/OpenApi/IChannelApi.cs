using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Channels;
using QQChannelSharp.Dto.Members;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 频道API接口
    /// </summary>
    public interface IChannelApi
    {
        /// <summary>
        /// 获取子频道信息
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        Task<HttpResult<Channel>> GetChannelAsync(string channelId);

        /// <summary>
        /// 获取子频道列表
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <returns></returns>
        Task<HttpResult<List<Channel>>> GetChannelsAsync(string guildId);

        /// <summary>
        /// 创建子频道
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="channel">子频道信息</param>
        /// <returns></returns>
        Task<HttpResult<Channel>> PostChannelAsync(string guildId, ChannelValueObject channel);

        /// <summary>
        /// 修改子频道
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="channel">子频道信息</param>
        /// <returns></returns>
        Task<HttpResult<Channel>> PatchChannelAsync(string guildId, ChannelValueObject channel);

        /// <summary>
        /// 创建子频道
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="channelId">子频道ID</param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> DeleteChannelAsync(string guildId, string channelId);

        /// <summary>
        /// 创建私密子频道
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="channel">子频道信息</param>
        /// <param name="userId">可访问私密子频道的用户ID</param>
        /// <returns></returns>
        Task<HttpResult<Channel>> CreatePrivateChannelAsync(string guildId, ChannelValueObject channel, IEnumerable<string> userId);

        /// <summary>
        /// 获取语音子频道在线成员列表
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <returns></returns>
        Task<HttpResult<List<Member>>> ListVoiceChannelMembersAsync(string channelId);
    }
}
