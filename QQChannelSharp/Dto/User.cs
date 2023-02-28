using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto
{
    /// <summary>
    /// User 用户
    /// </summary>
    public class User
    {
        [JsonPropertyName("id")]
        public required string ID { get; set; }

        [JsonPropertyName("username")]
        public required string Username { get; set; }

        [JsonPropertyName("avatar")]
        public required string Avatar { get; set; }

        [JsonPropertyName("bot")]
        public required bool Bot { get; set; }

        /// <summary>
        /// 特殊关联应用的 openid
        /// </summary>
        [JsonPropertyName("union_openid")]
        public required string UnionOpenID { get; set; }

        /// <summary>
        /// 机器人关联的用户信息，与union_openid关联的应用是同一个
        /// </summary>
        [JsonPropertyName("union_user_account")]
        public required string UnionUserAccount { get; set; }
    }
}
