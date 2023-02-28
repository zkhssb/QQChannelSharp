using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Mute
{
    /// <summary>
    /// 批量禁言的回参
    /// </summary>
    public class UpdateGuildMuteResponse
    {
        /// <summary>
        /// 批量禁言成功的成员列表
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("user_ids")]
        public string[]? UserIDs { get; set; }
    }
}
