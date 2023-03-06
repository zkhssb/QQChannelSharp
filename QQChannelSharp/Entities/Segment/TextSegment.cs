namespace QQChannelSharp.Segments
{
    public sealed class TextSegment : MessageSegment
    {
        private readonly string _text;
        public override SegmentType Type
            => SegmentType.Text;
        public TextSegment(string text)
        {
            _text = text;
        }
        public override string ToCommandText()
        {
            return _text;
        }
        public override string ToString()
        {
            return _text;
        }
    }
}