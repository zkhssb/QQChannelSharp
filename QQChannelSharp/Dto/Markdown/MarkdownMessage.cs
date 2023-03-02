using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Markdown
{
    /// <summary>
    /// markdown 消息
    /// </summary>
    public class MarkdownMessage
    {
        /// <summary>
        /// 模板ID
        /// </summary>
        [JsonPropertyName("template_id")]
        public required int TemplateId { get; set; }
        /// <summary>
        /// 模版参数
        /// </summary>
        [JsonPropertyName("params")]
        public required List<MarkdownParams> Params { get; set; }
        /// <summary>
        /// 原生Markdown
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
    }
}
