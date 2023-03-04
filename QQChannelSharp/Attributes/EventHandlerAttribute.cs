namespace QQChannelSharp.Attributes
{
    /// <summary>
    /// 事件处理器
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class EventHandlerAttribute : Attribute
    {
        /// <summary>
        /// 事件名字
        /// </summary>
        public string? Name { get; init; }
    }
}