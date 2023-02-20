using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.Direct
{
    /// <summary>
    /// DirectMessageToCreate 创建私信频道的结构体定义
    /// </summary>
    public class DirectMessageToCreate
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("source_guild_id")]
        public required string SourceGuildID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [JsonPropertyName("recipient_id")]
        public required string RecipientID { get; set; }
    }
}
