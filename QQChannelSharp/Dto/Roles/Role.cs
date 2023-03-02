using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Roles
{
    /// <summary>
    /// Role 频道身份组
    /// </summary>
    public class Role
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("id")]
        public string? ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("color")]
        public uint Color { get; set; } = 4278245297; //用户组默认颜色值

        [JsonPropertyName("hoist")]
        public uint Hoist { get; set; }

        /// <summary>
        /// 不会被修改，创建接口修改
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("number")]
        public uint? MemberCount { get; set; }

        /// <summary>
        /// 不会被修改，创建接口修改
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("member_limit")]
        public uint? MemberLimit { get; set; }
    }
}
