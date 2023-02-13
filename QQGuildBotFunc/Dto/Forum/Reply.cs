using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQGuildBotFunc.Dto.Forum
{
    /// <summary>
    /// Reply 回复事件主体内容
    /// </summary>
    public class Reply
    {
        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }

        [JsonPropertyName("channel_id")]
        public required string ChannelID { get; set; }

        [JsonPropertyName("author_id")]
        public required string AuthorID { get; set; }

        [JsonPropertyName("reply_info")]
        public required ReplyInfo ReplyInfo { get; set; }
    }
}
