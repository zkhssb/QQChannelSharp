using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.MessageArks
{
    /// <summary>
    /// ArkObjKV Ark 对象键值对
    /// </summary>
    public class ArkObjKV
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
