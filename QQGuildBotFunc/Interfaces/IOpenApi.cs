namespace QQGuildBotFunc.Interfaces
{
    public interface IOpenApi
    {
        /// <summary>
        /// 当前版本
        /// </summary>
        int Version();
        /// <summary>
        /// 获取 lastTraceID id
        /// </summary>
        string TraceID();
    }
}
