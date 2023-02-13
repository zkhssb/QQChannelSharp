using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQGuildBotFunc.Enumerations
{
    /// <summary>
    /// 子频道子类型
    /// </summary>
    public enum ChannelSubType
    {
        /// <summary>
        /// 闲聊,默认子频道
        /// </summary>
        Chat = 0,
        /// <summary>
        /// 公告
        /// </summary>
        Notice = 1,
        /// <summary>
        /// 攻略
        /// </summary>
        Guide = 2,
        /// <summary>
        /// 开黑
        /// </summary>
        TeamGame = 3
    }
}
