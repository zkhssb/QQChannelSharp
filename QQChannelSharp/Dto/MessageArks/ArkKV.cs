using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.MessageArks
{
    /// <summary>
    /// ArkKV Ark 键值对
    /// </summary>
    public class ArkKV
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("obj")]
        public ArkObj[]? Obj { get; set; }
    }
}
