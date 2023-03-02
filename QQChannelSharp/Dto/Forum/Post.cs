using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Forum
{
    /// <summary>
    /// Post 帖子事件主体内容
    /// </summary>
    public class Post
    {
        [JsonPropertyName("guild_id")]
        public string GuildID { get; set; } = string.Empty;

        [JsonPropertyName("channel_id")]
        public string ChannelID { get; set; } = string.Empty;

        [JsonPropertyName("author_id")]
        public string AuthorID { get; set; } = string.Empty;

        [JsonPropertyName("post_info")]
        public required PostInfo PostInfo { get; set; }
    }
}
