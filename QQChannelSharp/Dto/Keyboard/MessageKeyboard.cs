using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Keyboard
{
    /// <summary>
    /// 消息按钮组件
    /// </summary>
    public class MessageKeyboard
    {
        /// <summary>
        /// 消息按钮组件模板 ID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// 消息按钮组件自定义内容
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("content")]
        public CustomKeyboard? Content { get; set; }
    }
}
