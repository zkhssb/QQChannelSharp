using QQChannelSharp.Logger;

namespace QQChannelSharp.Tests.Logger
{
    public class MyLogger : IConsoleLogger
    {
        public void Log(LogLevel level, string source, object message)
        {
            Console.WriteLine("[{0}/{1}] {2}", level.ToString().ToLower(), source, message);
        }

        public void LogDebug(string source, object message)
        {
            Log(LogLevel.Debug, source, message);
        }

        public void LogError(string source, object message)
        {
            Log(LogLevel.Error, source, message);
        }

        public void LogFatal(string source, object message)
        {
            Log(LogLevel.Fatal, source, message);
        }

        public void LogInfo(string source, object message)
        {
            Log(LogLevel.Info, source, message);
        }

        public void LogWarning(string source, object message)
        {
            Log(LogLevel.Warning, source, message);
        }
    }
}