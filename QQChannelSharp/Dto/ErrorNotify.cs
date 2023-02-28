using QQChannelSharp.Enumerations;

namespace QQChannelSharp.Dto
{
    /// <summary>
    /// 错误通知
    /// </summary>
    public class ErrorNotify
    {
        /// <summary>
        /// 错误类型
        /// </summary>
        public required ErrorType Type { get; init; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public required string? Message { get; init; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public required int Code { get; init; }
    }
}
