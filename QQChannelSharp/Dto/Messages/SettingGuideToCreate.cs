using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Messages
{
    /// <summary>
    /// 发送引导消息的结构体
    /// </summary>
    public class SettingGuideToCreate
    {
        /// <summary>
        /// 频道内发引导消息可以带@
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("content")]
        public string? Content { get; set; }

        /// <summary>
        /// 设置引导
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("setting_guide")]
        public SettingGuide? SettingGuide { get; set; }
    }
}
