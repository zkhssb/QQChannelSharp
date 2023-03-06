namespace QQChannelSharp.Segments
{
    /// <summary>
    /// 消息段
    /// </summary>
    public abstract class MessageSegment
    {
        /// <summary>
        /// 类型
        /// </summary>
        public abstract SegmentType Type { get; }
        public abstract string ToCommandText();
    }
}