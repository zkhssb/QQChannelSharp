using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Forum;
/// <summary>
/// Thread 主题事件主体内容
/// </summary>
public class Thread
{
    [JsonPropertyName("guild_id")]
    public string GuildID { get; set; } = string.Empty;

    [JsonPropertyName("channel_id")]
    public string ChannelID { get; set; } = string.Empty;

    [JsonPropertyName("author_id")]
    public string AuthorID { get; set; } = string.Empty;

    [JsonPropertyName("thread_info")]
    public required ThreadInfo ThreadInfo { get; set; }
}