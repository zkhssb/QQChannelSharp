using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Forum
{
    /// <summary>
    /// ReplyInfo 回复内容
    /// </summary>
    public class ReplyInfo
    {
        [JsonPropertyName("thread_id")]
        public required string ThreadID { get; set; }

        [JsonPropertyName("post_id")]
        public required string PostID { get; set; }

        [JsonPropertyName("reply_id")]
        public required string ReplyID { get; set; }

        [JsonPropertyName("content")]
        public required string Content { get; set; }

        [JsonPropertyName("date_time")]
        public required string DateTime { get; set; }
    }
}
