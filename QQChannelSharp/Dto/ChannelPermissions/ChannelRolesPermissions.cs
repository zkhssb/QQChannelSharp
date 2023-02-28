using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.ChannelPermissions
{
    /// <summary>
    /// ChannelRolesPermissions 子频道身份组权限
    /// </summary>
    public class ChannelRolesPermissions
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("channel_id")]
        public string? ChannelID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("role_id")]
        public string? RoleID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("permissions")]
        public string? Permissions { get; set; }
    }
}
