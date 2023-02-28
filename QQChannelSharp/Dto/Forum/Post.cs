﻿using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Forum
{
    /// <summary>
    /// Post 帖子事件主体内容
    /// </summary>
    public class Post
    {
        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }

        [JsonPropertyName("channel_id")]
        public required string ChannelID { get; set; }

        [JsonPropertyName("author_id")]
        public required string AuthorID { get; set; }

        [JsonPropertyName("post_info")]
        public required PostInfo PostInfo { get; set; }
    }
}
