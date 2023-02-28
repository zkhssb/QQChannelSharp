using QQChannelSharp.Enumerations;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Options
{
    public class MemberDeleteOptions
    {
        /// <summary>
        /// 将当前成员同时添加到频道黑名单中
        /// </summary>
        [JsonPropertyName("add_blacklist")]
        public bool AddBlackList { get; set; }
        /// <summary>
        /// 删除成员时同时撤回消息
        /// </summary>
        [JsonPropertyName("delete_history_msg_days")]
        public DeleteHistoryMsgDay DeleteHistoryMsgDays { get; set; }

        /// <summary>
        /// 将当前成员同时添加到频道黑名单中
        /// </summary>
        public MemberDeleteOptions WithAddBlackList(bool addBlackList)
        {
            AddBlackList = addBlackList;
            return this;
        }
        /// <summary>
        /// 删除成员时同时撤回消息
        /// </summary>
        public MemberDeleteOptions WithDeleteHistoryMsg(DeleteHistoryMsgDay deleteHistoryMsgDays)
        {
            DeleteHistoryMsgDays = deleteHistoryMsgDays;
            return this;
        }
    }
}