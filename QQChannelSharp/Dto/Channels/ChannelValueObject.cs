using QQChannelSharp.Enumerations;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Channels
{
    /// <summary>
    /// ChannelValueObject 频道的值对象部分
    /// </summary>
    public class ChannelValueObject
    {
        /// <summary>
        /// 频道名称
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 排序位置
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("position")]
        public long? Position { get; set; }

        /// <summary>
        /// 父频道的ID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("parent_id")]
        public string? ParentID { get; set; }

        /// <summary>
        /// 拥有者ID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("owner_id")]
        public string? OwnerID { get; set; }

        /// <summary>
        /// 子频道子类型
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("sub_type")]
        public ChannelSubType? SubType { get; set; }

        /// <summary>
        /// 子频道可见性类型
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("private_type")]
        public ChannelPrivateType? PrivateType { get; set; }

        /// <summary>
        /// 创建私密子频道的时候，同时带上 userID，能够将这些成员添加为私密子频道的成员
        /// 注意：只有创建私密子频道的时候才支持这个参数
        /// <summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("private_user_ids")]
        public string[]? PrivateUserIDs { get; set; }

        /// <summary>
        /// 发言权限
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("speak_permission")]
        public SpeakPermissionType? SpeakPermission { get; set; }

        /// <summary>
        /// 应用子频道的应用ID，仅应用子频道有效，定义请参考
        /// [文档](https://bot.q.qq.com/wiki/develop/api/openapi/channel/model.html)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("application_id")]
        public string? ApplicationID { get; set; }

        /// <summary>
        /// 机器人在此频道上拥有的权限, 定义请参考
        /// [文档](https://bot.q.qq.com/wiki/develop/api/openapi/channel_permissions/model.html#permissions)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("permissions")]
        public string? Permissions { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("op_user_id")]
        public string? OpUserID { get; set; }
    }
}
