using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Message;
using QQChannelSharp.Dto.Messages;
using QQChannelSharp.Enumerations;
using QQChannelSharp.Interfaces;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Entities
{
    /// <summary>
    /// 消息类
    /// </summary>
    public sealed class MessageContext : BaseEntities
    {
        private Message _message;

        public Message Message
            => _message;
        public MessageContext(IOpenApi openApi, Message message) : base(openApi)
        {
            _message = message;
        }

        /// <summary>
        /// 撤回本条消息
        /// </summary>
        public async Task<HttpResult<EmptyObject>> RetractMessageAsync(IEnumerable<RetractMessageOption>? options = null)
        {
            return await OpenApi.RetractMessageAsync(_message.ChannelID, _message.ID, options);
        }

        /// <summary>
        /// 获取消息@列表
        /// </summary>
        public IEnumerable<User> GetATList()
        {
            return _message.Mentions ?? new User[0];
        }

        /// <summary>
        /// 引用并回复消息
        /// </summary>
        /// <param name="message">回复的消息</param>
        /// <param name="ignoreGetMessageError">是否忽律获取消息失败错误</param>
        /// <returns></returns>
        public async Task<HttpResult<Message>> ReplyMessageAsync(MessageToCreate message, bool ignoreGetMessageError = false)
        {
            if (message.MessageReference is not null)
                throw new InvalidOperationException($"原消息已有引用接口 (已引用消息: {message.MessageReference.MessageID})");
            message.MessageReference = new MessageReference()
            {
                MessageID = _message.ID,
                IgnoreGetMessageError = ignoreGetMessageError,
            };
            return await OpenApi.PostMessageAsync(_message.ChannelID, message);
        }
    }
}