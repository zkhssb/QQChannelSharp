using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Forum
{
    /// <summary>
    /// ThreadInfo 主题信息
    /// </summary>
    public class ThreadInfo
    {
        [JsonPropertyName("thread_id")]
        public string ThreadID { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonPropertyName("date_time")]
        public string DateTime { get; set; } = string.Empty;
    }
}
