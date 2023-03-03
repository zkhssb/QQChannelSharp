namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 普通事件事件
    /// <br/>
    /// 在解析数据包时，如果没有找到对应的处理器，就会调用 <see cref="PlainEvent"/> 来处理
    /// </summary>
    public class PlainEvent : BaseChannelEventArgs
    {

    }
}