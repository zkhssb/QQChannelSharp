using QQChannelSharp.Dto;
using QQChannelSharp.Dto.ChannelPermissions;
using QQChannelSharp.OpenApi;

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
        Task<HttpResult<Permissions>> ChannelPermissionsAsync(string channelId, string userId);
        /// <summary>
        /// 修改指定子频道的权限
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="channelPermissions">修改的权限</param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> PutChannelPermissionsAsync(string channelId, string userId, UpdateChannelPermissions channelPermissions);

        /// <summary>
        /// 获取指定子频道身份组的权限
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="roleId">身分组ID</param>
        /// <returns></returns>
        Task<HttpResult<ChannelRolesPermissions>> ChannelRolesPermissionsAsync(string channelId, string roleId);
        /// <summary>
        /// 修改指定子频道身份组的权限
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="roleId">身分组ID</param>
        /// <param name="channelPermissions">修改的权限</param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> PutChannelRolesPermissionsAsync(string channelId, string roleId, UpdateChannelPermissions channelPermissions);
    }
}
