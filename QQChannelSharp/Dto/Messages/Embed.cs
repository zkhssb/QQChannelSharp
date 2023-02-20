using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.Messages
{
    /// <summary>
    /// Embed 结构
    /// </summary>
    public class Embed
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// 消息弹窗内容，消息列表摘要
        /// </summary>
        [JsonPropertyName("prompt")]
        public required string Prompt { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("thumbnail")]
        public MessageEmbedThumbnail? Thumbnail { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("fields")]
        public EmbedField[]? Fields { get; set; }
    }
}
