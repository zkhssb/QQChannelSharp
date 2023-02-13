using System.Text.Json.Serialization;

namespace QQGuildBotFunc.Dto.WebSocket
{
    /// <summary>
    /// (发送)重连数据
    /// <br/>
    /// https://bot.q.qq.com/wiki/develop/api/gateway/reference.html#_4-%E6%81%A2%E5%A4%8D%E8%BF%9E%E6%8E%A5
    /// </summary>
    public class WSResumeData : WebSocketDataBase
    {
        [JsonPropertyName("token")]
        public required string Token { get; set; }
        [JsonPropertyName("session_id")]
        public required string SessionID { get; set; }
        [JsonPropertyName("seq")]
        public required int Seq { get; set; }
    }
}
