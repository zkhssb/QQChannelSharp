using QQChannelSharp.Enumerations;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Options
{
    /// <summary>
    /// 删除成员选项
    /// </summary>
    public class MemberDeleteOptions
    {
        /// <summary>
        /// 将当前成员同时添加到频道黑名单中
        /// </summary>
        [JsonPropertyName("add_blacklist")]
        public bool AddBlackList { get; set; }
        /// <summary>
        /// 删除消息天数
        /// </summary>
        [JsonPropertyName("delete_history_msg_days")]
        public DeleteHistoryMsgDay DeleteHistoryMsgDays { get; set; } = DeleteHistoryMsgDay.NoDelete;
        /// <summary>
        /// 将当前成员同时添加到频道黑名单中
        /// </summary>
        public MemberDeleteOptions WithAddBlackList(bool addBlackList)
        {
            AddBlackList = addBlackList;
            return this;
        }
        /// <summary>
        /// 删除范围内消息
        /// </summary>
        public MemberDeleteOptions WithDeleteHistoryMsg(DeleteHistoryMsgDay deleteHistoryMsgDays)
        {
            DeleteHistoryMsgDays = deleteHistoryMsgDays;
            return this;
        }
    }
}
