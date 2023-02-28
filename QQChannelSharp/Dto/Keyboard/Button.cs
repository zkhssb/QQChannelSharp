using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Keyboard
{
    public class Button
    {
        /// <summary>
        /// 按钮 ID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        /// <summary>
        /// 渲染展示字段
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("render_data")]
        public RenderData? RenderData { get; set; }

        /// <summary>
        /// 该按纽操作相关字段
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("action")]
        public Action? Action { get; set; }
    }
}
