﻿using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Forum;
/// <summary>
/// Thread 主题事件主体内容
/// </summary>
public class Thread
{
    [JsonPropertyName("guild_id")]
    public required string GuildID { get; set; }

    [JsonPropertyName("channel_id")]
    public required string ChannelID { get; set; }

    [JsonPropertyName("author_id")]
    public required string AuthorID { get; set; }

    [JsonPropertyName("thread_info")]
    public required ThreadInfo ThreadInfo { get; set; }
}