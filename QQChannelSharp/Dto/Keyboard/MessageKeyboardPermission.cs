using QQChannelSharp.Enumerations;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Keyboard
{
    /// <summary>
    /// 按纽操作权限
    /// </summary>
    public class MessageKeyboardPermission
    {
        /// <summary>
        /// Type 操作权限类型
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("type")]
        public MessageKeyboardPermissionType? PermissionType { get; set; }

        /// <summary>
        /// 指定身份组
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("specify_role_ids")]
        public List<string>? SpecifyRoleIds { get; set; }

        /// <summary>
        /// 指定用户ID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("specify_user_ids")]
        public List<string>? SpecifyUserIds { get; set; }
    }
}
