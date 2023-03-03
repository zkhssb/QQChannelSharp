using QQChannelSharp.Dto.Message;
using QQChannelSharp.Enumerations;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 消息审核事件
    /// </summary>
    public class MessageAuditEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 审核结果
        /// </summary>
        public required MessageAuditType Result { get; init; }

        /// <summary>
        /// 消息审核数据
        /// </summary>
        public required MessageAudit Audit { get; init; }
    }
}