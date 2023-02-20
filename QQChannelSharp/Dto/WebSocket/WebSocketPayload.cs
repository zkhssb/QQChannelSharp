using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.WebSocket
{
    /// <summary>
    /// websocket 消息结构
    /// </summary>
    public class WebSocketPayload : WebSocketPayloadBase
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("d")]
        public object? Data { get; set; }
        [JsonIgnore]
        public string RawMessage { get; set; } = string.Empty;
    }
}
