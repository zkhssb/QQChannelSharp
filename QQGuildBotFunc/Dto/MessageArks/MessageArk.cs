using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQGuildBotFunc.Dto.MessageArks
{
    /// <summary>
    /// MessageArk ark模板消息
    /// </summary>
    public class MessageArk
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("ark")]
        public Ark? Ark { get; set; }
    }
}
