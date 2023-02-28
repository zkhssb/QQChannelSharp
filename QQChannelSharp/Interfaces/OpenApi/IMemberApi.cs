using QQChannelSharp.Dto.Mute;
using QQChannelSharp.Dto.Roles;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 成员相关接口，添加成员到用户组等
    /// </summary>
    public interface IMemberApi
    {
        /// <summary>
        /// 添加成员到用户组
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="roleId">用户组ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="value">添加数据</param>
        /// <returns></returns>
        Task MemberAddRoleAsync(string guildId, string roleId, string userId, MemberAddRoleBody value);

        /// <summary>
        /// 删除成员用户组
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="roleId">用户组ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="value">删除数据</param>
        /// <returns></returns>
        Task MemberDeleteRoleAsync(string guildId, string roleId, string userId, MemberAddRoleBody value);

        /// <summary>
        /// 频道指定单个成员禁言
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="mute">禁言信息</param>
        /// <returns></returns>
        Task MemberMuteAsync(string guildId, string userId, UpdateGuildMute mute);

        /// <summary>
        /// 批量禁言频道成员
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="mute">禁言信息</param>
        /// <returns></returns>
        Task<UpdateGuildMuteResponse> MultiMemberMuteAsync(string guildId, UpdateGuildMute mute);
    }
}
