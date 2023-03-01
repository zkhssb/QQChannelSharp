namespace QQChannelSharp.OpenApi
{
    public class OpenApiFactoryOptions
    {
        private readonly ChannelBotInfo _botInfo;

        public OpenApiFactoryOptions(ChannelBotInfo botInfo)
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
        public bool Polly { get; set; }

        /// <summary>
        /// 单次重连次数
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// 单次重连间隔(单位:秒)
        /// </summary>
        public int RetryInterval { get; set; }

        /// <summary>
        /// 使用Polly
        /// </summary>
        /// <param name="retryCount">重试次数</param>
        /// <param name="retryInterval">重试间隔</param>
        /// <returns></returns>
        public OpenApiFactoryOptions UsePolly(int retryCount, int retryInterval)
        {
            Polly = true;
            RetryCount = retryCount;
            RetryInterval = retryInterval;
            return this;
        }

        /// <summary>
        /// 使用Polly
        /// <br/>
        /// 默认配置(重试三次每次间隔5秒)
        /// </summary>
        /// <returns></returns>
        public OpenApiFactoryOptions UsePolly()
        {
            return UsePolly(3, 5);
        }
    }
}
