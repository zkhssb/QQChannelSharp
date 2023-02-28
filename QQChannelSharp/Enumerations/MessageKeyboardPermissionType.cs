namespace QQChannelSharp.Enumerations
{
    public enum MessageKeyboardPermissionType
    {
        /// <summary>
        /// 仅指定这条消息的人可操作
        /// </summary>
        SpecifyUserIDs = 0,
        /// <summary>
        /// 仅频道管理者可操作
        /// </summary>
        Manager = 1,
        /// <summary>
        /// 所有人可操作
        /// </summary>
        All = 2,
        /// <summary>
        /// 指定身份组可操作
        /// </summary>
        SpecifyRoleIDs = 3,
    }
}
