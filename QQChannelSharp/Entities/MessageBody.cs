using QQChannelSharp.Dto.Messages;
using QQChannelSharp.Enumerations;
using QQChannelSharp.Segments;

namespace QQChannelSharp.Entities
{
    public class MessageBody : MessageToCreate
    {
        private readonly List<MessageSegment> _messageSegments = new();
        public MessageBody() { }
        public MessageBody(string content, string? messageId)
        {
            _messageSegments.Add(new TextSegment(content));
            MsgId = messageId;
        }
        public MessageBody(string content) : this(content, null)
        {

        }
        public override string? Content
        {
            get => string.Join(string.Empty, _messageSegments.Select(e => e.ToCommandText()));
        }
        /// <summary>
        /// 附带图片
        /// </summary>
        /// <param name="imageUrl">图片地址</param>
        /// <returns></returns>
        public new MessageBody Image(string imageUrl)
        {
            base.Image = imageUrl;
            return this;
        }

        /// <summary>
        /// 附带消息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        public MessageBody Text(string content)
        {
            _messageSegments.Add(new TextSegment(content));
            return this;
        }

        /// <summary>
        /// 换行消息
        /// </summary>
        public MessageBody EndLine()
        {
            _messageSegments.Add(new TextSegment("\n"));
            return this;
        }

        /// <summary>
        /// 附带消息段
        /// </summary>
        /// <param name="segments">
        /// 附带消息段<br/>
        /// <see cref="Segment.At(string)"/><br/>
        /// <see cref="Segment.Channel(string)"/><br/>
        /// <see cref="Segment.Emoji(string)"/><br/>
        /// <see cref="Segment.Text(string)"/><br/>
        /// </param>
        /// <returns></returns>
        public MessageBody Segment(params MessageSegment[] segments)
        {
            foreach (var segment in segments)
            {
                _messageSegments.Add(segment);
            }
            return this;
        }

        /// <summary>
        /// 附带Emoji
        /// </summary>
        /// <param name="emojis">EmojiID列表</param>
        /// <returns></returns>
        public MessageBody Emoji(params int[] emojis)
        {
            foreach (var emoji in emojis)
            {
                _messageSegments.Add(new EmojiSegment(emoji.ToString()));
            }
            return this;
        }

        /// <summary>
        /// 附带Emoji
        /// </summary>
        /// <param name="emojis">Emoji类型</param>
        /// <returns></returns>
        public MessageBody Emoji(params EmojiType[] emojis)
            => Emoji(emojis.Select(e => (int)e).ToArray());
    }
}