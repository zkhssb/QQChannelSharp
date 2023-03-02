using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Message
{
    /// <summary>
    /// MessageAudit 消息审核结构体定义
    /// </summary>
    public class MessageAudit
    {
        /// <summary>
        /// 审核 ID
        /// </summary>
        [JsonPropertyName("audit_id")]
        public string AuditID { get; set; } = string.Empty;

        /// <summary>
        /// 消息 ID
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageID { get; set; } = string.Empty;

        /// <summary>
        /// 频道 ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildID { get; set; } = string.Empty;

        /// <summary>
        /// 子频道 ID
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelID { get; set; } = string.Empty;

        /// <summary>
        /// 审核时间
        /// </summary>
        [JsonPropertyName("audit_time")]
        public string AuditTime { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; } = string.Empty;

        /// <summary>
        /// 子频道 seq，用于消息间的排序，seq 在同一子频道中按从先到后的顺序递增，不同的子频道之前消息无法排序
        /// </summary>
        [JsonPropertyName("seq_in_channel")]
        public string SeqInChannel { get; set; } = string.Empty;
    }
}
