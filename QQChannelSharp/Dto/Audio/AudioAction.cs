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
        public string GuildID { get; set; } = string.Empty;
        /// <summary>
        /// 子频道ID
        /// </summary>

        [JsonPropertyName("channel_id")]
        public string ChannelID { get; set; } = string.Empty;
        /// <summary>
        /// 音频链接
        /// </summary>

        [JsonPropertyName("audio_url")]
        public string URL { get; set; } = string.Empty;

        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
    }
}
