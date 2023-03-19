using System.Text.Json.Serialization;

namespace QQChannelSharp.WebSocket
{
    /// <summary>
    /// ShardConfig 连接的 shard 配置，ShardID 从 0 开始，ShardCount 最小为 1
    /// </summary>
    public class ShardConfig
    {
        [JsonPropertyName("shard_id")]
        public required int ShardID { get; set; }
        [JsonPropertyName("shard_count")]
        public int ShardCount { get; set; } = 1;
    }
}
