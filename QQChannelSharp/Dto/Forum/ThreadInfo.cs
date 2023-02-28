using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Forum
{
    /// <summary>
    /// ThreadInfo 主题信息
    /// </summary>
    public class ThreadInfo
    {
        [JsonPropertyName("thread_id")]
        public required string ThreadID { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("content")]
        public required string Content { get; set; }

        [JsonPropertyName("date_time")]
        public required string DateTime { get; set; }
    }
}
