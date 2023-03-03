using QQChannelSharp.Logger;

namespace QQChannelSharp.Tests.Logger
{
    [TestClass]
    public class LogTests
    {
        [TestMethod]
        public void LogSetLoggerTest()
        {
            Log.SetLogger(new MyLogger());
            foreach (var level in Enum.GetValues(typeof(LogLevel)))
            {
                Log.LogOut((LogLevel)level, "Test", "输出测试");
            }
        }

        [TestMethod]
        public void LogTest()
        {
            Log.SetLogger();
            foreach (var level in Enum.GetValues(typeof(LogLevel)))
            {
                Log.LogOut((LogLevel)level, "Test", "输出测试");
            }
        }
    }
}