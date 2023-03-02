using QQChannelSharp.Enumerations;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Audio
{
    /// <summary>
    /// AudioControl 音频控制对象
    /// </summary>
    public class AudioControl
    {
        /// <summary>
        /// 音频URL
        /// </summary>
        [JsonPropertyName("audio_url")]
        public string URL { get; set; } = string.Empty;
        /// <summary>
        /// 音频描述
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
        /// <summary>
        /// 音频状态
        /// </summary>
        [JsonPropertyName("status")]
        public AudioStatus Status { get; set; }
    }
}
