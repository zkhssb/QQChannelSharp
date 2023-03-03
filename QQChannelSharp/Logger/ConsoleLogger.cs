using System.Diagnostics;
using System.Reflection;

namespace QQChannelSharp.Logger
{
    public class ConsoleLogger : IConsoleLogger
    {
        private object _consoleLock = new object();
        private string getTypeName()
        {
            StackFrame frame = new StackFrame(4);
            if (null == frame)
            {
                return string.Empty;
            }
            MethodBase? method = frame.GetMethod();
            if (null == method || null == method.DeclaringType)
            {
                return string.Empty;
            }
            string? name = method.DeclaringType.ReflectedType?.FullName;
            if (string.IsNullOrEmpty(name))
            {
                return method.DeclaringType.FullName ?? string.Empty;
            }
            return name;
        }
        private void log(LogLevel logLevel, string source, object message, ConsoleColor color)
        {
            lock (_consoleLock)
            {
                Console.BackgroundColor = color;
                Console.Write(" ");
                Console.ResetColor();
                Console.ForegroundColor = color;
                Console.Write(" " + logLevel + " ");
                Console.ResetColor();
                Console.Write(DateTime.Now.ToString());
                Console.Write(" " + getTypeName() + "[" + source + "]");
                Console.Write("\n");
                Console.BackgroundColor = color;
                Console.Write(" ");
                Console.ResetColor();
                Console.Write(" ");
                Console.WriteLine(message);
            }
        }
        public void Log(LogLevel level, string source, object message)
        {
            log(level, source, message, level switch
            {
                LogLevel.Debug => ConsoleColor.Cyan,
                LogLevel.Info => ConsoleColor.DarkGreen,
                LogLevel.Warning => ConsoleColor.DarkYellow,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Fatal => ConsoleColor.DarkRed,
                _ => ConsoleColor.Cyan
            });
        }

        public void LogDebug(string source, object message)
        {
            log(LogLevel.Debug, source, message, ConsoleColor.Cyan);
        }

        public void LogError(string source, object message)
        {
            log(LogLevel.Error, source, message, ConsoleColor.DarkRed);
        }

        public void LogFatal(string source, object message)
        {
            log(LogLevel.Fatal, source, message, ConsoleColor.DarkRed);
        }

        public void LogInfo(string source, object message)
        {
            log(LogLevel.Info, source, message, ConsoleColor.Green);
        }

        public void LogWarning(string source, object message)
        {
            log(LogLevel.Warning, source, message, ConsoleColor.DarkYellow);
        }
    }
}
