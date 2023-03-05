namespace QQChannelSharp.EventArgs
{
    public class HandlerErrorEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 引发的异常
        /// </summary>
        public required Exception Exception { get; init; }
    }
}