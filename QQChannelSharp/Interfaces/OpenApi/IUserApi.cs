using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Pager;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Interfaces.OpenApi
{
    public interface IUserApi
    {
        /// <summary>
        /// 获取自身信息
        /// </summary>
        Task<HttpResult<User>> MeAsync();
        /// <summary>
        /// 获取自身频道信息
        /// </summary>
        /// <param name="pager">页面</param>
        Task<HttpResult<List<Guild>>> MeGuildsAsync(GuildPager pager);
    }
}
