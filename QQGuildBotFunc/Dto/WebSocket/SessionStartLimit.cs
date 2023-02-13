using System.Text.Json.Serialization;

namespace QQGuildBotFunc.Dto.WebSocket
{
    /// <summary>
    /// 连接频控信息
    /// </summary>
    public class SessionStartLimit
    {
        /// <summary>
        /// 每 24 小时可创建 Session 数
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        /// <summary>
        /// 目前还可以创建的 Session 数
        /// </summary>
        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }
        /// <summary>
        /// 重置计数的剩余时间(ms)
        /// </summary>
        [JsonPropertyName("reset_after")]
        public int ResetAfter { get; set; }
        /// <summary>
        /// 每 5s 可以创建的 Session 数
        /// </summary>
        [JsonPropertyName("max_concurrency")]
        public int MaxConcurrency { get; set; }
    }
}
