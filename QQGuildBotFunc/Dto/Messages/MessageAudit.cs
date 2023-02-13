using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQGuildBotFunc.Dto.Message
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
        public required string AuditID { get; set; }

        /// <summary>
        /// 消息 ID
        /// </summary>
        [JsonPropertyName("message_id")]
        public required string MessageID { get; set; }

        /// <summary>
        /// 频道 ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }

        /// <summary>
        /// 子频道 ID
        /// </summary>
        [JsonPropertyName("channel_id")]
        public required string ChannelID { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        [JsonPropertyName("audit_time")]
        public required string AuditTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonPropertyName("create_time")]
        public required string CreateTime { get; set; }

        /// <summary>
        /// 子频道 seq，用于消息间的排序，seq 在同一子频道中按从先到后的顺序递增，不同的子频道之前消息无法排序
        /// </summary>
        [JsonPropertyName("seq_in_channel")]
        public required string SeqInChannel { get; set; }
    }
}
