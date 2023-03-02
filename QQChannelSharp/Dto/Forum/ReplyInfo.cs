using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Forum
{
    /// <summary>
    /// ReplyInfo 回复内容
    /// </summary>
    public class ReplyInfo
    {
        [JsonPropertyName("thread_id")]
        public string ThreadID { get; set; } = string.Empty;

        [JsonPropertyName("post_id")]
        public string PostID { get; set; } = string.Empty;

        [JsonPropertyName("reply_id")]
        public string ReplyID { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonPropertyName("date_time")]
        public string DateTime { get; set; } = string.Empty;
    }
}
