using QQGuildBotFunc.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQGuildBotFunc.Dto
{
    /// <summary>
    /// ReactionTarget 表态对象类型
    /// </summary>
    public class ReactionTarget
    {
        [JsonPropertyName("id")]
        public required string ID { get; set; }
        /// <summary>
        /// 表态对象类型
        /// </summary>
        [JsonPropertyName("type")]
        public required ReactionTargetType Type { get; set; }
    }
}
