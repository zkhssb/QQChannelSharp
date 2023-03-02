using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Forum
{
    /// <summary>
    /// PostInfo 帖子内容
    /// </summary>
    public class PostInfo
    {
        [JsonPropertyName("thread_id")]
        public string ThreadID { get; set; } = string.Empty;

        [JsonPropertyName("post_id")]
        public string PostID { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonPropertyName("date_time")]
        public string DateTime { get; set; } = string.Empty;
    }
}
