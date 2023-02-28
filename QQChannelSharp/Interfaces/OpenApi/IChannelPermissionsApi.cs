using QQChannelSharp.Dto.ChannelPermissions;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 子频道权限相关接口
    /// </summary>
    public interface IChannelPermissionsApi
    {
        /// <summary>
        /// 获取指定子频道的权限
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        Task<Permissions> ChannelPermissionsAsync(string channelId, string userId);
        /// <summary>
        /// 修改指定子频道的权限
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="channelPermissions">修改的权限</param>
        /// <returns></returns>
        Task PutChannelPermissionsAsync(string channelId, string userId, UpdateChannelPermissions channelPermissions);

        /// <summary>
        /// 获取指定子频道身份组的权限
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="roleId">身分组ID</param>
        /// <returns></returns>
        Task<ChannelRolesPermissions> ChannelRolesPermissionsAsync(string channelId, string roleId);
        /// <summary>
        /// 修改指定子频道身份组的权限
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="roleId">身分组ID</param>
        /// <param name="channelPermissions">修改的权限</param>
        /// <returns></returns>
        Task PutChannelRolesPermissionsAsync(string channelId, string roleId, UpdateChannelPermissions channelPermissions);
    }
}
