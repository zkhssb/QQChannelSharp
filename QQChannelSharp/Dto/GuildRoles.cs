using QQChannelSharp.Dto.Roles;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto
{
    /// <summary>
    /// 频道用户组列表返回
    /// </summary>
    public class GuildRoles
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public required string GuildId { get; set; }

        /// <summary>
        /// 身份组列表
        /// </summary>
        [JsonPropertyName("roles")]
        public required List<Role> Roles { get; set; }

        /// <summary>
        /// 身分组数量限制
        /// </summary>

        [JsonPropertyName("role_num_limit")]

        public required string NumLimit { get; set; }
    }
}
