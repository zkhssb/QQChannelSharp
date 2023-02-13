using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQGuildBotFunc.Dto.Channels
{
    /// <summary>
    /// 频道对象
    /// </summary>
    public class Channel : ChannelValueObject
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("id")]
        public string? ID { get; set; }
        /// <summary>
        /// 群ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string? GuildID { get; set; }
    }
}
