using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQGuildBotFunc.Dto.MessageArks
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
    }
}
