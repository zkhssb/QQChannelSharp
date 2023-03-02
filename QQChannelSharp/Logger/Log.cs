using System.Diagnostics;

namespace QQChannelSharp.Logger
{
    public static class Log
    {
        private static IConsoleLogger _consoleLogger = new ConsoleLogger();
        public static LogConfiguration Configuration { get; } = new LogConfiguration();
        /// <summary>
        /// 设置新的Logger实例 (默认为自带的ConsoleLogger)
        /// </summary>
        /// <param name="logger">新的Logger实例</param>
        public static void SetLogger(IConsoleLogger logger)
        {
            _consoleLogger = logger;
        }
        public static void LogOut(LogLevel level, string source, string message)
        {
            if (Configuration.EnableOutput && Configuration.LogLevel <= level)
            {
                _consoleLogger.Log(level, source, message);
            }
        }
        public static void LogDebug(string source, string message)
        {
            if (Configuration.EnableOutput && Configuration.LogLevel <= LogLevel.Debug)
            {
                _consoleLogger.LogDebug(source, message);
            }
        }
        public static void LogInfo(string source, string message)
        {
            if (Configuration.EnableOutput && Configuration.LogLevel <= LogLevel.Info)
            {
                _consoleLogger.LogInfo(source, message);
            }
        }
        public static void LogWarning(string source, string message)
        {
            if (Configuration.EnableOutput && Configuration.LogLevel <= LogLevel.Warning)
            {
                _consoleLogger.LogWarning(source, message);
            }
        }
        public static void LogError(string source, string message)
        {
            if (Configuration.EnableOutput && Configuration.LogLevel <= LogLevel.Error)
            {
                _consoleLogger.LogError(source, message);
            }
        }
        public static void LogFatal(string source, string message, bool quit = false)
        {
            if (Configuration.EnableOutput && Configuration.LogLevel <= LogLevel.Fatal)
            {
                _consoleLogger.LogFatal(source, message);
            }
            if (quit)
                Process.GetCurrentProcess().Kill();
        }
    }
}