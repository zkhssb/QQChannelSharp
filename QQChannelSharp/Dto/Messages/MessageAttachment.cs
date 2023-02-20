using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.Messages
{
    /// <summary>
    /// MessageAttachment 附件定义
    /// </summary>
    public class MessageAttachment
    {
        [JsonPropertyName("url")]
        public required string URL { get; set; }
    }
}
