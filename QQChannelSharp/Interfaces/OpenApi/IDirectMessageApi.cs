using QQChannelSharp.Dto.Direct;
using QQChannelSharp.Dto.Message;
using QQChannelSharp.Dto.Messages;
using QQChannelSharp.Enumerations;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 私信相关接口
    /// </summary>
    public interface IDirectMessageApi
    {
        /// <summary>
        /// 创建私信会话
        /// </summary>
        /// <param name="directMessage">创建私信数据</param>
        /// <returns>返回私信会话对象</returns>
        Task<DirectMessage> CreateDirectMessageAsync(DirectMessageToCreate directMessage);

        /// <summary>
        /// 发送私信
        /// </summary>
        /// <param name="directMessage">私信会话对象</param>
        /// <param name="message">私信消息</param>
        /// <returns></returns>
        Task<Message> PostDirectMessageAsync(DirectMessage directMessage, MessageToCreate message);

        /// <summary>
        /// 撤回私信频道消息
        /// </summary>
        /// <param name="guildId">私信频道ID</param>
        /// <param name="messageId">消息ID</param>
        /// <param name="options">撤回选项</param>
        /// <returns></returns>
        Task RetractDMMessageAsync(string guildId, string messageId, IEnumerable<RetractMessageOption>? options = null);

        /// <summary>
        /// 发送私信设置引导
        /// </summary>
        /// <param name="directMessage">私信会话对象</param>
        /// <param name="jumpGuildId">要引导跳转的频道ID</param>
        /// <returns></returns>
        Task<Message> PostDMSettingGuideAsync(DirectMessage directMessage, string jumpGuildId);
    }
}
