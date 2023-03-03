using QQChannelSharp.EventArgs;

namespace QQChannelSharp.Events;

/// <summary>
/// 事件异步回调
/// </summary>
public delegate Task EventAsyncCallBackHandler<in TEventArgs>(TEventArgs eventArgs)
    where TEventArgs : BaseChannelEventArgs;

/// <summary>
/// 时间错误异步回调
/// </summary>
public delegate Task EventErrorAsyncCallBackHandler(Exception exception);