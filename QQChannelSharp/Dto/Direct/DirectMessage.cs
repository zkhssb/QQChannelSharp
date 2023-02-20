using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.Direct
{
    /// <summary>
    /// DirectMessage 私信结构定义，一个 DirectMessage 为两个用户之间的一个私信频道，简写为 DM
    /// </summary>
    public class DirectMessage
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }

        /// <summary>
        /// 子频道id
        /// </summary>
        [JsonPropertyName("channel_id")]
        public required string ChannelID { get; set; }

        /// <summary>
        /// 私信频道创建的时间戳
        /// </summary>
        [JsonPropertyName("create_time")]
        public required string CreateTime { get; set; }
    }
}
