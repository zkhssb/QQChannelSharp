using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Pager;

namespace QQChannelSharp.Interfaces.OpenApi
{
    public interface IUserApi
    {
        /// <summary>
        /// 获取自身信息
        /// </summary>
        Task<User> MeAsync();
        /// <summary>
        /// 获取自身频道信息
        /// </summary>
        /// <param name="pager">页面</param>
        Task<List<Guild>> MeGuildsAsync(GuildPager pager);
    }
}
