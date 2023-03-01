using QQChannelSharp.Dto.Message;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Interfaces.OpenApi
{
    public interface IMessageSettingApi
    {
        /// <summary>
        /// 频道消息设置接口
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <returns></returns>
        Task<HttpResult<MessageSetting>> GetMessageSettingAsync(string guildId);
    }
}
