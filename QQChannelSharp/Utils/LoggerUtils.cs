using Microsoft.Extensions.Logging;

namespace QQChannelSharp.Utils
{
    public class LoggerUtils
    {
        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(build =>
        {
            build.AddConsole();
        });

        /// <summary>
        /// 创建一个新的日志实例
        /// </summary>
        public static ILogger<T> CreateLogger<T>()
        {
            return _loggerFactory.CreateLogger<T>();
        }
    }
}
