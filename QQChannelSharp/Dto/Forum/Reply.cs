using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Forum
{
    /// <summary>
    /// Reply 回复事件主体内容
    /// </summary>
    public class Reply
    {
        [JsonPropertyName("guild_id")]
        public string GuildID { get; set; } = string.Empty;

        [JsonPropertyName("channel_id")]
        public string ChannelID { get; set; } = string.Empty;

        [JsonPropertyName("author_id")]
        public string AuthorID { get; set; } = string.Empty;

        [JsonPropertyName("reply_info")]
        public required ReplyInfo ReplyInfo { get; set; }
    }
}
