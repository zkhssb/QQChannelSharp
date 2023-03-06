using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Message;
using QQChannelSharp.Dto.Messages;
using QQChannelSharp.Enumerations;
using QQChannelSharp.Interfaces;
using QQChannelSharp.OpenApi;
using QQChannelSharp.Segments;

namespace QQChannelSharp.Entities
{
    /// <summary>
    /// 消息类
    /// </summary>
    public sealed class MessageContext : BaseEntities
    {
        private Message _message;
        private List<MessageSegment> _segments;
        public IEnumerable<MessageSegment> Segments
            => _segments;

        public Message Message
            => _message;
        public MessageContext(IOpenApi openApi, Message message) : base(openApi)
        {
            _message = message;
            _segments = GetSegments(message.Content);

            static List<MessageSegment> GetSegments(string message)
            {
                var segments = new List<MessageSegment>();
                var currentIndex = 0;

                while (currentIndex < message.Length)
                {
                    var segmentStartIndex = message.IndexOf('<', currentIndex);

                    if (segmentStartIndex < 0)
                    {
                        // 文本中没有更多的段，将剩余的文本作为一个文本段添加。
                        var remainingText = message.Substring(currentIndex);
                        segments.Add(new TextSegment(remainingText));
                        break;
                    }

                    if (segmentStartIndex > currentIndex)
                    {
                        // 在下一个片段之前有一些文本，把它作为一个文本片段添加。
                        var textBeforeSegment = message[currentIndex..segmentStartIndex];
                        segments.Add(new TextSegment(textBeforeSegment));
                    }

                    var segmentEndIndex = message.IndexOf('>', segmentStartIndex);

                    if (segmentEndIndex < 0)
                    {
                        // 没有匹配的结束语'>'为当前段开始的'<'，将其余的文本作为一个文本段添加。
                        var remainingText = message[segmentStartIndex..];
                        segments.Add(new TextSegment(remainingText));
                        break;
                    }

                    var segmentText = message[(segmentStartIndex + 1)..segmentEndIndex];

                    switch (segmentText)
                    {
                        case string s1 when s1.StartsWith("!@"):
                        case string s2 when s2.StartsWith("@!"):
                            var segmentId = segmentText[(segmentText.IndexOf(':') + 3)..];
                            segments.Add(new ATSegment(segmentId));
                            break;

                        case string s when s.StartsWith("@"):
                            var segmentId2 = segmentText[(segmentText.IndexOf(':') + 1)..];
                            segments.Add(new ATSegment(segmentId2));
                            break;

                        case string s when s.StartsWith("emoji:"):
                            var emojiId = segmentText[(segmentText.IndexOf(':') + 1)..];
                            segments.Add(new EmojiSegment(emojiId));
                            break;

                        default:
                            // 未知段类型，将其作为一个文本段添加。
                            var segment = message[segmentStartIndex..(segmentEndIndex + 1)];
                            segments.Add(new TextSegment(segment));
                            break;
                    }

                    currentIndex = segmentEndIndex + 1;
                }

                return segments;
            }
        }
        /// <summary>
        /// 获取消息中的文本 (去除@字段、子频道指引字段、表情字段)
        /// </summary>
        /// <returns></returns>
        public string GetText()
            => (string.Join(string.Empty,
                _segments
                    .Where(e => e is TextSegment)
                    .Select(e => e.ToCommandText()))
                ?? string.Empty).Trim();

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