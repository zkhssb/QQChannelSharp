using QQChannelSharp.Dto.ApiPermissions;

namespace QQChannelSharp.Interfaces.OpenApi
{
    public interface IAPIPermissionsApi
    {
        /// <summary>
        /// 获取频道可用权限列表
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <returns></returns>
        Task<APIPermissions> GetPermissionAsync(string guildId);

        /// <summary>
        /// 创建频道 API 接口权限授权链接
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <param name="demand">授权信息</param>
        /// <returns></returns>
        Task<APIPermissionDemand> RequireAPIPermissions(string guildId, APIPermissionDemandToCreate demand);
    }
}
