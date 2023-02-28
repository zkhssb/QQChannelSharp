using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Interactions
{
    /// <summary>
    /// Interaction 互动行为对象
    /// </summary>
    public class Interaction
    {
        /// <summary>
        /// 互动行为唯一标识
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("id")]
        public string? ID { get; set; }

        /// <summary>
        /// 应用ID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("application_id")]
        public string? ApplicationID { get; set; }

        /// <summary>
        /// 互动数据
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("data")]
        public InteractionData? Data { get; set; }

        /// <summary>
        /// 频道 ID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("guild_id")]
        public string? GuildID { get; set; }

        /// <summary>
        /// 子频道 ID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("channel_id")]
        public string? ChannelID { get; set; }

        /// <summary>
        /// 版本，默认为 1
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("version")]
        public uint? Version { get; set; }
    }
}
