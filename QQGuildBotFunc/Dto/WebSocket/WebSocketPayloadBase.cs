using QQGuildBotFunc.Enumerations;
using System.Text.Json.Serialization;

namespace QQGuildBotFunc.Dto.WebSocket
{
    /// <summary>
    /// WSPayloadBase 基础消息结构，排除了 data
    /// </summary>
    public abstract class WebSocketPayloadBase
    {
        [JsonPropertyName("op")]
        public OPCode OPCode { get; set; }
        [JsonPropertyName("s")]
        public int Seq { get; set; }
        [JsonPropertyName("t")]
        public string? EventType { get; set; }
    }
}
