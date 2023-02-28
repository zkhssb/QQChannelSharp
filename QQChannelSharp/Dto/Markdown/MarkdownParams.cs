using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Markdown
{
    /// <summary>
    /// 模版参数 键值对
    /// </summary>
    public class MarkdownParams
    {
        [JsonPropertyName("key")]
        public required string Key { get; set; }

        [JsonPropertyName("values")]
        public required List<string> Values { get; set; }
    }
}
