namespace QQChannelSharp.Utils
{
    /// <summary>
    /// 实现 session manager 所需要的公共方法。
    /// </summary>
    public class SessionManagerUtils
    {
        // 设置并发时间窗口大小为2秒
        private const double concurrencyTimeWindowSec = 2.0;
        /// <summary>
        /// 根据并发要求，计算连接启动间隔
        /// </summary>
        public static TimeSpan CalcInterval(int maxConcurrency)
        {
            if (maxConcurrency == 0)
                maxConcurrency = 1;
            double f = Math.Round(concurrencyTimeWindowSec / maxConcurrency);
            if (f == 0)
                f = 1;
            return TimeSpan.FromSeconds(f);
        }
        /// <summary>
        /// 是否是不能够 resume 的错误
        /// </summary>
        public static bool CanNotResume(int code)
        {
            return code == 9005; // 9005  关闭连接错误码，收拢 websocket close error，不允许 resume
        }
        /// <summary>
        /// 是否是不能够 identify 的错误
        /// </summary>
        public static bool CanNotIdentify(int code)
        {
            return code == 9006; // 9006  不允许连接的关闭连接错误，比如机器人被封禁
        }
    }
}
