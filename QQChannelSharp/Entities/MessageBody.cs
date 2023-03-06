using QQChannelSharp.Dto.Messages;

namespace QQChannelSharp.Entities
{
    public class MessageBody : MessageToCreate
    {
        public MessageBody() { }
        public MessageBody(string content, string? messageId)
        {
            Content = content;
            MsgId = messageId;
        }
        public MessageBody(string content) : this(content, null)
        {

        }

        /// <summary>
        /// 附带图片
        /// </summary>
        /// <param name="imageUrl">图片地址</param>
        /// <returns></returns>
        public MessageBody WithImage(string imageUrl)
        {
            Image = imageUrl;
            return this;
        }

        /// <summary>
        /// 附带消息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        public MessageBody WithContent(string content)
        {
            Content = content;
            return this;
        }
    }
}