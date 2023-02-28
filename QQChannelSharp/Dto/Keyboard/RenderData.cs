using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Keyboard
{
    public class RenderData
    {
        /// <summary>
        /// 按钮上的文字
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("label")]
        public string? Label { get; set; }
        /// <summary>
        /// 点击后按纽上文字
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("visited_label")]
        public string? VisitedLabel { get; set; }

        /// <summary>
        /// 按钮样式，0：灰色线框，1：蓝色线框
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("style")]
        public int? Style { get; set; }
    }
}
