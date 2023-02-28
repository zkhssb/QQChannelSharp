using QQChannelSharp.Enumerations;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Keyboard
{
    /// <summary>
    /// 按纽点击操作
    /// </summary>
    public class Action
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("type")]
        public MessageKeyboardActionType? ActionType { get; set; }
        /// <summary>
        /// 可操作
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("permission")]
        public MessageKeyboardPermission? Permission { get; set; }
        /// <summary>
        /// 可点击的次数, 默认不限
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("click_limit")]
        public int? ClickLimit { get; set; }
        /// <summary>
        /// 操作相关数据
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("data")]
        public string? Data { get; set; }
        /// <summary>
        /// 弹出展示子频道选择器
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("at_bot_show_channel_list")]
        public bool? AtBotShowChannelList { get; set; }
    }
}
