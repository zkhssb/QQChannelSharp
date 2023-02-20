using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.WebSocket
{
    /// <summary>
    /// wss 接入点信息
    /// </summary>
    public class WebsocketAP
    {
        /// <summary>
        /// WSS链接地址
        /// </summary>
        [JsonPropertyName("url")]
        public required string Url { get; set; }
        /// <summary>
        /// 建议分片数
        /// </summary>
        [JsonPropertyName("shards")]
        public int Shards { get; set; }
        /// <summary>
        /// 链接频控信息
        /// </summary>
        [JsonPropertyName("session_start_limit")]
        public required SessionStartLimit SessionStartLimit { get; set; }
    }
}
