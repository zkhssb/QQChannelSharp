using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Keyboard
{
    /// <summary>
    /// Row 每行结构
    /// </summary>
    public class Row
    {
        /// <summary>
        /// 每行按钮
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("buttons")]
        public List<Button>? Buttons { get; set; }
    }
}
