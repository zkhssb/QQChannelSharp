using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Keyboard
{
    /// <summary>
    /// 自定义 Keyboard
    /// </summary>
    public class CustomKeyboard
    {
        /// <summary>
        /// 行数组
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("rows")]
        public List<Row>? Rows { get; set; }
    }
}
