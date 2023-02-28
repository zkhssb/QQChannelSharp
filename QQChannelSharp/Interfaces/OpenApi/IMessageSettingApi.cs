using QQChannelSharp.Dto.Message;

namespace QQChannelSharp.Interfaces.OpenApi
{
    public interface IMessageSettingApi
    {
        /// <summary>
        /// 频道消息设置接口
        /// </summary>
        /// <param name="guildId">频道ID</param>
        /// <returns></returns>
        Task<MessageSetting> GetMessageSettingAsync(string guildId);
    }
}
