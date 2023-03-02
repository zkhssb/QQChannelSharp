using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Forum
{
    /// <summary>
    /// ForumAuditResult 帖子审核事件主体内容
    /// </summary>
    public class ForumAuditResult
    {
        [JsonPropertyName("task_id")]
        public string TaskID { get; set; } = string.Empty;

        [JsonPropertyName("guild_id")]
        public string GuildID { get; set; } = string.Empty;

        [JsonPropertyName("channel_id")]
        public string ChannelID { get; set; } = string.Empty;

        [JsonPropertyName("author_id")]
        public string AuthorID { get; set; } = string.Empty;

        [JsonPropertyName("thread_id")]
        public string ThreadID { get; set; } = string.Empty;

        [JsonPropertyName("post_id")]
        public string PostID { get; set; } = string.Empty;

        [JsonPropertyName("reply_id")]
        public string ReplyID { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public uint PublishType { get; set; }

        [JsonPropertyName("result")]
        public uint Result { get; set; }

        [JsonPropertyName("err_msg")]
        public string ErrMsg { get; set; } = string.Empty;

        [JsonPropertyName("date_time")]
        public string DateTime { get; set; } = string.Empty;
    }
}
