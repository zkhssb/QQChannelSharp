namespace QQChannelSharp.Enumerations
{
    /// <summary>
    /// 按钮操作类型
    /// </summary>
    public enum MessageKeyboardActionType
    {
        /// <summary>
        /// http 或 小程序 客户端识别 schema, data字段为链接
        /// </summary>
        Url = 0,
        /// <summary>
        /// 回调互动回调地址, data 传给互动回调地址
        /// </summary>
        Callback = 1,
        /// <summary>
        /// at机器人, 根据 at_bot_show_channel_list 决定在当前频道或用户选择频道,自动在输入框 @bot data
        /// </summary>
        AtBot = 2,
    }
}
