using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Members;
using QQChannelSharp.Dto.Mute;
using QQChannelSharp.Dto.Options;
using QQChannelSharp.Dto.Pager;

namespace QQChannelSharp.Interfaces.OpenApi
{
    public interface IGuildApi
    {
        /// <summary>
        /// 获取频道信息
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <returns></returns>
        Task<Guild> GetGuildAsync(string guildId);
        /// <summary>
        /// 获取频道成员
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        Task<Member> GetGuildMemberAsync(string guildId, string userId);
        /// <summary>
        /// 批量获取频道成员
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="pager">选择器</param>
        /// <returns></returns>
        Task<List<Member>> GetGuildMembersAsync(string guildId, GuildMembersPager pager);
        /// <summary>
        /// 删除频道成员
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="options">删除选项</param>
        /// <returns></returns>
        Task DeleteGuildMemberAsync(string guildId, string userId, MemberDeleteOptions? options = null);
        /// <summary>
        /// 频道禁言
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="mute">禁言信息</param>
        /// <returns></returns>
        Task GuildMuteAsync(string guildId, UpdateGuildMute mute);
    }
}
