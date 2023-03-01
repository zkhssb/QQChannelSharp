using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Roles;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 用户组相关接口
    /// </summary>
    public interface IRoleApi
    {
        /// <summary>
        /// 获取频道身分组列表
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <returns></returns>
        Task<HttpResult<GuildRoles>> GetRolesAsync(string guildId);

        /// <summary>
        /// 创建用户组
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="role">创建的用户组</param>
        /// <returns></returns>
        Task<HttpResult<UpdateResult>> PostRoleAsync(string guildId, Role role);

        /// <summary>
        /// 更改用户组信息
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="roleId">用户组ID</param>
        /// <param name="role">新的用户组信息</param>
        /// <returns></returns>
        Task<HttpResult<UpdateResult>> PatchRoleAsync(string guildId, string roleId, Role role);

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="roleId">用户组ID</param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> DeleteRoleAsync(string guildId, string roleId);
    }
}
