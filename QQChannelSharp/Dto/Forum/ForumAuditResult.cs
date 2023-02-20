using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.Forum
{
    /// <summary>
    /// ForumAuditResult 帖子审核事件主体内容
    /// </summary>
    public class ForumAuditResult
    {
        [JsonPropertyName("task_id")]
        public required string TaskID { get; set; }

        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }

        [JsonPropertyName("channel_id")]
        public required string ChannelID { get; set; }

        [JsonPropertyName("author_id")]
        public required string AuthorID { get; set; }

        [JsonPropertyName("thread_id")]
        public required string ThreadID { get; set; }

        [JsonPropertyName("post_id")]
        public required string PostID { get; set; }

        [JsonPropertyName("reply_id")]
        public required string ReplyID { get; set; }

        [JsonPropertyName("type")]
        public required uint PublishType { get; set; }

        [JsonPropertyName("result")]
        public required uint Result { get; set; }

        [JsonPropertyName("err_msg")]
        public required string ErrMsg { get; set; }

        [JsonPropertyName("date_time")]
        public required string DateTime { get; set; }
    }
}
