using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.WebSocket
{
    /// <summary>
    /// Properties目前无实际作用，可以按照自己的实际情况填写，也可以留空
    /// </summary>
    public class Properties
    {
        public static Properties Default
        {
            get => new Properties()
            {
                Os = $"{Environment.OSVersion.VersionString} {(Environment.Is64BitOperatingSystem ? "X64" : "X86")}",
            };
        }
        /// <summary>
        /// 系统
        /// </summary>
        [JsonPropertyName("os")]
        public string? Os { get; set; }
        /// <summary>
        /// 浏览器?
        /// </summary>
        [JsonPropertyName("browser")]
        public string? Browser { get; set; }
        /// <summary>
        /// 设备
        /// </summary>
        [JsonPropertyName("device")]
        public string? Device { get; set; }

    }
    /// <summary>
    /// (发送)鉴权数据
    /// <br/>
    /// https://bot.q.qq.com/wiki/develop/api/gateway/reference.html#_2-%E9%89%B4%E6%9D%83%E8%BF%9E%E6%8E%A5
    /// </summary>
    public class WSIdentityData : WebSocketDataBase
    {
        /// <summary>
        /// Token
        /// </summary>
        [JsonPropertyName("token")]
        public required string Token { get; set; }
        /// <summary>
        /// 监听事件
        /// </summary>
        [JsonPropertyName("intents")]
        public int Intents { get; set; }
        /// <summary>
        /// 分片
        /// </summary>
        [JsonPropertyName("shard")]
        public int[] Shard { get; set; } = new int[1];
        /// <summary>
        /// 属性
        /// 可以为空,官方说这玩意暂时没有实际作用
        /// </summary>
        [JsonPropertyName("properties")]
        public Properties? Properties { get; set; } = Properties.Default;

    }
}