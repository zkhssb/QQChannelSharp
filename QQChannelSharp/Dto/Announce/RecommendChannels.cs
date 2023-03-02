using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Announce
{
    // https://bot.q.qq.com/wiki/develop/api/openapi/announces/model.html#announces

    /// <summary>
    /// 推荐子频道对象
    /// </summary>
    public class RecommendChannels
    {
        /// <summary>
        /// 子频道ID
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelID { get; set; } = string.Empty;
        /// <summary>
        /// 推荐语
        /// </summary>
        [JsonPropertyName("introduce")]
        public string Introduce { get; set; } = string.Empty;
    }
}
