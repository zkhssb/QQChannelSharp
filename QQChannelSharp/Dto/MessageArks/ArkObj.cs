using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
