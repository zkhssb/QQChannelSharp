namespace QQChannelSharp.Logger
{
    public interface IConsoleLogger
    {
        void Log(LogLevel level, string source, object message);
        void LogDebug(string source, object message);
        void LogInfo(string source, object message);
        void LogWarning(string source, object message);
        void LogError(string source, object message);
        void LogFatal(string source, object message);
    }
}
