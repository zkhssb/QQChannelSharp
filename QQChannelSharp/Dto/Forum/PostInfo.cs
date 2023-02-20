using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.Forum
{
    /// <summary>
    /// PostInfo 帖子内容
    /// </summary>
    public class PostInfo
    {
        [JsonPropertyName("thread_id")]
        public required string ThreadID { get; set; }

        [JsonPropertyName("post_id")]
        public required string PostID { get; set; }

        [JsonPropertyName("content")]
        public required string Content { get; set; }

        [JsonPropertyName("date_time")]
        public required string DateTime { get; set; }
    }
}
