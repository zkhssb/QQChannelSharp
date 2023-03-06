namespace QQChannelSharp.Segments
{
    /// <summary>
    /// QQ官方黄豆表情
    /// </summary>
    public class EmojiSegment : MessageSegment
    {
        private readonly string _emojiId;
        public EmojiSegment(string emojiId)
        {
            _emojiId = emojiId;
        }

        public override SegmentType Type
            => SegmentType.Emoji;

        public override string ToCommandText()
        {
            return $"<emoji:{_emojiId}>";
        }
        public override string ToString()
        {
            return _emojiId;
        }
    }
}