using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.WebSocket
{
    /// <summary>
    /// (接收)初次连接
    /// <br/>
    /// https://bot.q.qq.com/wiki/develop/api/gateway/reference.html#_1-%E8%BF%9E%E6%8E%A5%E5%88%B0-gateway
    /// </summary>
    public class WSHelloData : WebSocketDataBase
    {
        [JsonPropertyName("heartbeat_interval")]
        public int HeartbeatInterval { get; set; }
    }
}
