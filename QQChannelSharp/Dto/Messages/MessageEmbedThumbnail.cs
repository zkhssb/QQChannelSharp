using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.Messages
{
    /// <summary>
    /// MessageEmbedThumbnail embed 消息的缩略图对象
    /// </summary>
    public class MessageEmbedThumbnail
    {
        [JsonPropertyName("url")]
        public required string URL { get; set; }
    }
}
