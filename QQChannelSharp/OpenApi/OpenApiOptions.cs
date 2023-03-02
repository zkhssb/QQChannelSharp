namespace QQChannelSharp.OpenApi
{
    public class OpenApiOptions
    {
        private readonly ChannelBotInfo _botInfo;

        public OpenApiOptions(ChannelBotInfo botInfo)
        {
            _botInfo = botInfo;
        }

        /// <summary>
        /// 机器人信息
        /// </summary>
        public ChannelBotInfo BotInfo
            => _botInfo;

        /// <summary>
        /// 使用Polly(重连)
        /// </summary>
        public bool Retry { get; set; }

        /// <summary>
        /// 单次重连次数
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// 单次重连间隔
        /// </summary>
        public TimeSpan RetryInterval { get; set; }

        /// <summary>
        /// 使用指数退避算法重连策略
        /// </summary>
        /// <param name="retryCount">重试次数</param>
        /// <param name="retryInterval">重试间隔</param>
        /// <returns></returns>
        public OpenApiOptions UseRetry(int retryCount, TimeSpan retryInterval)
        {
            Retry = true;
            RetryCount = retryCount;
            RetryInterval = retryInterval;
            return this;
        }

        /// <summary>
        /// 使用指数退避算法重连策略
        /// <br/>
        /// 默认配置(重试5次每次间隔1秒)
        /// </summary>
        /// <returns></returns>
        public OpenApiOptions UseRetry()
        {
            return UseRetry(5, TimeSpan.FromSeconds(1));
        }
    }
}
