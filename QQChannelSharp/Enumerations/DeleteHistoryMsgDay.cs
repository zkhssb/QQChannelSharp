using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQChannelSharp.Enumerations
{
    public enum DeleteHistoryMsgDay
    {
        /// <summary>
        /// 不删除任何消息
        /// </summary>
        NoDelete = 0,  // 不删除任何消息
        /// <summary>
        /// 3天
        /// </summary>
        DeleteThreeDays = 3,
        /// <summary>
        /// 7天
        /// </summary>
        DeleteSevenDays = 7,
        /// <summary>
        /// 15天
        /// </summary>
        DeleteFifteenDays = 15,
        /// <summary>
        /// 30天
        /// </summary>
        DeleteThirtyDays = 30,
        /// <summary>
        /// 删除所有消息
        /// </summary>
        DeleteAll = -1
    }
}
