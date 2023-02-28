using QQChannelSharp.Dto.Channels;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto
{
    /// <summary>
    /// Guild 频道结构定义
    /// </summary>
    public class Guild
    {
        /// <summary>
        /// 频道ID（与客户端上看到的频道ID不同）
        /// </summary>
        [JsonPropertyName("id")]
        public required string ID { get; set; }

        /// <summary>
        /// 频道名称
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        /// <summary>
        /// 频道头像
        /// </summary>
        [JsonPropertyName("icon")]
        public required string Icon { get; set; }

        /// <summary>
        /// 拥有者ID
        /// </summary>
        [JsonPropertyName("owner_id")]
        public required string OwnerID { get; set; }

        /// <summary>
        /// 是否为拥有者
        /// </summary>
        [JsonPropertyName("owner")]
        public required bool IsOwner { get; set; }

        /// <summary>
        /// 成员数量
        /// </summary>
        [JsonPropertyName("member_count")]
        public required int MemberCount { get; set; }

        /// <summary>
        /// 最大成员数目
        /// </summary>
        [JsonPropertyName("max_members")]
        public required long MaxMembers { get; set; }

        /// <summary>
        /// 频道描述
        /// </summary>
        [JsonPropertyName("description")]
        public required string Desc { get; set; }

        /// <summary>
        /// 当前用户加入群的时间
        /// 此字段只在GUILD_CREATE事件中使用
        /// </summary>
        [JsonPropertyName("joined_at")]
        public required DateTime JoinedAt { get; set; }

        /// <summary>
        /// 频道列表
        /// </summary>
        [JsonPropertyName("channels")]
        public required Channel[] Channels { get; set; }

        /// <summary>
        /// 游戏绑定公会区服ID
        /// </summary>
        [JsonPropertyName("union_world_id")]
        public required string UnionWorldID { get; set; }

        /// <summary>
        /// 游戏绑定公会/战队ID
        /// </summary>
        [JsonPropertyName("union_org_id")]
        public required string UnionOrgID { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("op_user_id")]
        public string? OpUserID { get; set; }
    }
}
