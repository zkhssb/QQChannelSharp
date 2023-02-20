using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.WebSocket
{
    /// <summary>
    /// (接收)Bot鉴权成功
    /// <br/>
    /// https://bot.q.qq.com/wiki/develop/api/gateway/reference.html#_2-%E9%89%B4%E6%9D%83%E8%BF%9E%E6%8E%A5
    /// </summary>
    public class WSReadyData : WebSocketDataBase
    {
        /// <summary>
        /// 版本
        /// </summary>
        [JsonPropertyName("version")]
        public int Version { get; set; }
        /// <summary>
        /// 会话ID
        /// </summary>
        [JsonPropertyName("session_id")]
        public required string SessionID { get; set; }
        /// <summary>
        /// 鉴权成功的用户信息
        /// </summary>
        [JsonPropertyName("user")]
        public required WSUser User { get; set; }
        /// <summary>
        /// 分片
        /// </summary>
        [JsonPropertyName("shard")]
        public required int[] Shard { get; set; }
    }
}