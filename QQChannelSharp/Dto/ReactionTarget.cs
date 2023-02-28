using QQChannelSharp.Enumerations;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto
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
