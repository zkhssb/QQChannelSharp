using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    public class OpenApiRes
    {
        /// <summary>
        /// 测试用的, 文件格式为: BotAppId AppToken
        /// 例: 1145141919810 qwdhqwoirfqwecorqwgqwogqh
        /// </summary>
        private readonly static string[] _botInfo = File.ReadAllText("C:/Users/16490/Desktop/TextBot.txt").Split(" ");

        /// <summary>
        /// Bot选项
        /// </summary>
        private readonly static OpenApiOptions _options = new(new ChannelBotInfo(_botInfo[0], _botInfo[1], true))
        {
            Retry = true,
            RetryCount = 5,
            RetryInterval = TimeSpan.FromSeconds(1)
        };

        /// <summary>
        /// OpenApi实例
        /// </summary>
        private readonly static QQChannelSharp.OpenApi.OpenApi _openApi
            = (QQChannelSharp.OpenApi.OpenApi)OpenApiFactory.Create(_options);

        public static QQChannelSharp.OpenApi.OpenApi OpenApi
            => _openApi;
    }
}
