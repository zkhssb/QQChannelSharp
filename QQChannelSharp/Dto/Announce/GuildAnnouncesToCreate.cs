using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Announce
{
    // https://bot.q.qq.com/wiki/develop/api/openapi/announces/post_guild_announces.html

    /// <summary>
    /// 创建频道全局公告接口参数
    /// </summary>
    public class GuildAnnouncesToCreate
    {
        /// <summary>
        /// 用来创建公告的子频道 ID
        /// <br/>
        /// 可以为 <see cref="string.Empty"/>
        /// </summary>
        [JsonPropertyName("channel_id")]
        public required string ChannelID { get; set; }
        /// <summary>
        /// 用来创建公告的消息 ID
        /// <br/>
        /// 可以为 <see cref="string.Empty"/>
        /// </summary>
        [JsonPropertyName("message_id")]
        public required string MessageID { get; set; }
        /// <summary>
        ///  公告类别 0:成员公告，1:欢迎公告，默认为成员公告
        /// </summary>
        [JsonPropertyName("announces_type")]
        public required int AnnouncesType { get; set; }
        /// <summary>
        /// 推荐子频道详情列表
        /// </summary>
        [JsonPropertyName("recommend_channels")]
        public IEnumerable<RecommendChannels>? RecommendChannels { get; set; }
    }
}
