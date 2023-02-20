using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.Messages
{
    /// <summary>
    /// PinsMessage 精华消息对象
    /// </summary>
    public class PinsMessage
    {
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
        /// 消息 ID 数组
        /// </summary>
        [JsonPropertyName("message_ids")]
        public required string[] MessageIDs { get; set; }
    }

}
