using QQChannelSharp.Dto.Forum;

namespace QQChannelSharp.EventArgs
{
    public class ForumAuditEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 审核结果
        /// </summary>
        public required ForumAuditResult Result { get; init; }
    }
}