using System.Text.Json.Serialization;

namespace QQGuildBotFunc.Dto.Announce
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
        public required string ChannelID { get; set; }
        /// <summary>
        /// 推荐语
        /// </summary>
        [JsonPropertyName("introduce")]
        public required string Introduce { get; set; }
    }
}
