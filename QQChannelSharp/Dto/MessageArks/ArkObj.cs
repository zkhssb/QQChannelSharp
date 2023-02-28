using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.MessageArks
{
    /// <summary>
    /// Ark 对象
    /// </summary>
    public class ArkObj
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("obj_kv")]
        public ArkObjKV[]? ObjKV { get; set; }
    }
}
