﻿using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Message
{
    /// <summary>
    /// MessageSetting 消息频率设置信息
    /// </summary>
    public class MessageSetting
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("disable_create_dm")]
        public bool? DisableCreateDm { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("disable_push_msg")]
        public bool? DisablePushMsg { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("channel_ids")]
        public string[]? ChannelIDs { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("channel_push_max_num")]
        public int? ChannelPushMaxNum { get; set; }
    }
}
