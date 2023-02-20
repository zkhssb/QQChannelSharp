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
        public required string URL { get; set; }
        /// <summary>
        /// 音频描述
        /// </summary>
        [JsonPropertyName("text")]
        public required string Text { get; set; }
        /// <summary>
        /// 音频状态
        /// </summary>
        [JsonPropertyName("status")]
        public AudioStatus Status { get; set; }
    }
}
