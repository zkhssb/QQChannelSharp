using System.Text.Json.Serialization;

namespace QQChannelSharp.WebSocket
{
    /// <summary>
    /// Session 连接的 session 结构，包括链接的所有必要字段
    /// </summary>
    public class Session
    {
        [JsonPropertyName("guid")]
        public required Guid Guid { get; init; }
        [JsonPropertyName("shard")]
        public required ShardConfig Shard { get; set; }
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("url")]
        public required string Url { get; set; }
        [JsonPropertyName("bot_info")]
        public required ChannelBotInfo BotInfo { get; set; }
        [JsonPropertyName("intent")]
        public required int Intent { get; set; }
        [JsonPropertyName("seq")]
        public required long LastSeq { get; set; }
    }
}
