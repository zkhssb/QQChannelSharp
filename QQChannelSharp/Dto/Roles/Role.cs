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
        public static string? ID { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("color")]
        public required uint Color { get; set; }

        [JsonPropertyName("hoist")]
        public required uint Hoist { get; set; }

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
