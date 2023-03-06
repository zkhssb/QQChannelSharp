namespace QQChannelSharp.Segments
{
    public class ATSegment : MessageSegment
    {
        private readonly string _userId;
        public override SegmentType Type
            => SegmentType.At;
        public ATSegment(string userId)
        {
            _userId = userId;
        }
        public override string ToCommandText()
        {
            return $"<!@{_userId}>";
        }
        public override string ToString()
        {
            return _userId;
        }
    }
}