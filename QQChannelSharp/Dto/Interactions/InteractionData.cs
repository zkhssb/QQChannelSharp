using QQChannelSharp.Enumerations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Interactions
{
    /// <summary>
    /// 互动数据
    /// </summary>
    public class InteractionData
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("type")]
        public InteractionDataType? Type { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("resolved")]
        public JsonElement? Resolved { get; set; }
    }
}
