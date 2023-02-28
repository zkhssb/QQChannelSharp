using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.MessageArks
{
    /// <summary>
    /// Ark 消息模版
    /// </summary>
    public class Ark
    {
        /// <summary>
        /// ark 模版 ID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("template_id")]
        public int? TemplateID { get; set; }
        /// <summary>
        /// ArkKV 数组
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("kv")]
        public ArkKV? KV { get; set; }
    }
}
