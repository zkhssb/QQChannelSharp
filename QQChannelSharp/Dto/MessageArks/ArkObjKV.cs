using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
