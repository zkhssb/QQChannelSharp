namespace QQChannelSharp.Segments
{
    /// <summary>
    /// 子频道指引
    /// </summary>
    public class ChannelSegment : MessageSegment
    {
        private readonly string _channelId;
        public override SegmentType Type
            => SegmentType.Channel;
        public ChannelSegment(string channelId)
        {
            _channelId = channelId;
        }
        public override string ToCommandText()
        {
            return $"<#{_channelId}>";
        }
        public override string ToString()
        {
            return _channelId;
        }
    }
}