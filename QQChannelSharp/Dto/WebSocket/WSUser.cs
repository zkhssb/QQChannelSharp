using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.WebSocket
{
    /// <summary>
    /// 当前连接的用户信息
    /// </summary>
    public class WSUser
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        [JsonPropertyName("username")]
        public required string Username { get; set; }
        /// <summary>
        /// 是否为Bot
        /// </summary>
        [JsonPropertyName("bot")]
        public bool IsBot { get; set; }
    }
}
