using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Audio
{
    /// <summary>
    /// AudioAction 音频动作
    /// </summary>
    public class AudioAction
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }
        /// <summary>
        /// 子频道ID
        /// </summary>

        [JsonPropertyName("channel_id")]
        public required string ChannelID { get; set; }
        /// <summary>
        /// 音频链接
        /// </summary>

        [JsonPropertyName("audio_url")]
        public required string URL { get; set; }

        [JsonPropertyName("text")]
        public required string Text { get; set; }
    }
}
