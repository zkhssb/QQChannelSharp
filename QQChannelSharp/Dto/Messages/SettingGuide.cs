using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Messages
{
    /// <summary>
    /// 设置引导
    /// </summary>
    public class SettingGuide
    {
        /// <summary>
        /// 频道ID, 当通过私信发送设置引导消息时，需要指定guild_id
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }
    }
}
