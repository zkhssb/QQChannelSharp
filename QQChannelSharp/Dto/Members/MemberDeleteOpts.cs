using QQChannelSharp.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.Members
{
    /// <summary>
    /// 删除成员额外参数
    /// </summary>
    public class MemberDeleteOpts
    {
        /// <summary>
        /// 加入黑名单
        /// </summary>
        [JsonPropertyName("add_blacklist")]
        public bool AddBlackList { get; set; } = false;
        /// <summary>
        /// 删除消息天数
        /// </summary>
        [JsonPropertyName("delete_history_msg_days")]
        public DeleteHistoryMsgDay DeleteHistoryMsgDays { get; set; } = DeleteHistoryMsgDay.NoDelete;
        /// <summary>
        /// 是否加入黑名单
        /// </summary>
        public MemberDeleteOpts WithAddBlackList(bool addBlackList)
        {
            AddBlackList = addBlackList;
            return this;
        }
        /// <summary>
        /// 删除范围内消息
        /// </summary>
        public MemberDeleteOpts WithDeleteHistoryMsg(DeleteHistoryMsgDay deleteHistoryMsgDays)
        {
            DeleteHistoryMsgDays = deleteHistoryMsgDays;
            return this;
        }
    }
}
