namespace QQChannelSharp.Segments
{
    /// <summary>
    /// 分段类型
    /// </summary>
    public enum SegmentType
    {
        /// <summary>
        /// 无法识别的类型
        /// </summary>
        None,
        /// <summary>
        /// 文字消息段
        /// </summary>
        Text,
        /// <summary>
        /// QQ官方表情
        /// </summary>
        Emoji,
        /// <summary>
        /// @消息段
        /// </summary>
        At,
        /// <summary>
        /// 子频道消息段
        /// </summary>
        Channel,
    }
}