namespace QQChannelSharp.Segments
{
    public class Segment
    {
        /// <summary>
        /// 文本分段
        /// </summary>
        public static MessageSegment Text(string text)
            => new TextSegment(text);
        /// <summary>
        /// @用户
        /// </summary>
        /// <param name="userId">要AT的人</param>
        /// <returns></returns>
        public static ATSegment At(string userId)
            => new ATSegment(userId);

        /// <summary>
        /// QQ黄豆表情
        /// </summary>
        /// <param name="emojiId">表情ID</param>
        /// <returns></returns>
        public static EmojiSegment Emoji(int emojiId)
            => new EmojiSegment(emojiId.ToString());

        /// <summary>
        /// 子频道指引
        /// </summary>
        /// <param name="channelId">子频道名</param>
        /// <returns></returns>
        public static ChannelSegment Channel(string channelId)
            => new ChannelSegment(channelId);

        public static TextSegment ATAll()
            => new TextSegment("@everyone");
    }
}