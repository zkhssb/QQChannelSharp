﻿using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Announce
{
    // https://bot.q.qq.com/wiki/develop/api/openapi/announces/model.html#announces

    /// <summary>
    /// 公告对象
    /// </summary>
    public class Announces
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildID { get; set; } = string.Empty;
        /// <summary>
        /// 子频道ID
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelID { get; set; } = string.Empty;
        /// <summary>
        /// 用来创建公告的消息ID
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageID { get; set; } = string.Empty;
        /// <summary>
        /// 公告类别 0:成员公告，1:欢迎公告，默认为成员公告
        /// </summary>
        [JsonPropertyName("announces_type")]
        public int AnnouncesType { get; set; }
        /// <summary>
        /// 推荐子频道详情列表
        /// </summary>
        [JsonPropertyName("recommend_channels")]
        public IEnumerable<RecommendChannels>? RecommendChannels { get; set; }
    }
}
