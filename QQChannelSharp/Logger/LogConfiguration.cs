namespace QQChannelSharp.Logger
{
    public class LogConfiguration
    {
        internal bool EnableOutput;
        internal LogLevel LogLevel;
        public LogConfiguration()
        {
            EnableOutput = true;
            LogLevel = LogLevel.Info;
        }
        public LogConfiguration EnableConsoleOutput()
        {
            this.EnableOutput = true;
            return this;
        }

        public LogConfiguration DisableConsoleOutput()
        {
            this.EnableOutput = false;
            return this;
        }

        public LogConfiguration SetLogLevel(LogLevel value)
        {
            LogLevel = value;
            return this;
        }
    }
}