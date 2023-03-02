using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Direct
{
    /// <summary>
    /// DirectMessage 私信结构定义，一个 DirectMessage 为两个用户之间的一个私信频道，简写为 DM
    /// </summary>
    public class DirectMessage
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildID { get; set; } = string.Empty;

        /// <summary>
        /// 子频道id
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelID { get; set; } = string.Empty;

        /// <summary>
        /// 私信频道创建的时间戳
        /// </summary>
        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; } = string.Empty;
    }
}
