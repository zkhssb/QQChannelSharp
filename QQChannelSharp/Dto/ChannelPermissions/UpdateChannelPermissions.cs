﻿using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.ChannelPermissions
{
    /// <summary>
    /// UpdateChannelPermissions 修改子频道权限参数
    /// </summary>
    public class UpdateChannelPermissions
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("add")]
        public string? Add { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("remove")]
        public string? Remove { get; set; }
    }
}
