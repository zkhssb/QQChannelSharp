using System.Text.Json.Serialization;

namespace QQGuildBotFunc.Dto.WebSocket
{
    /// <summary>
    /// websocket 消息结构
    /// </summary>
    public class WebSocketPayload : WebSocketPayloadBase
    {
        [JsonPropertyName("d")]
        public WebSocketDataBase? Data { get; set; }
        [JsonIgnore]
        public string RawMessage { get; set; } = string.Empty;
    }
}
