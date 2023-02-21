using QQChannelSharp.Enumerations;
using System.Text.Json.Serialization;

namespace QQChannelSharp
{
    public partial class ChannelBotInfo
    {
        #region 公开成员
        /// <summary>
        /// 机器人APPID
        /// </summary>
        public string AppId { get; private set; } = string.Empty;
        /// <summary>
        /// 机器人令牌
        /// </summary>
        public string Token { get; private set; } = string.Empty;
        /// <summary>
        /// 机器人监听消息
        /// </summary>
        public int Intents { get; private set; }
        /// <summary>
        /// 是否沙盒模式
        /// </summary>
        public bool SandBox { get; private set; }
        public string FullToken { get => $"{AppId}.{Token}"; }

        /// <summary>
        /// 用于请求Api的Uri
        /// </summary>
        public Uri ApiUri
        {
            get => new Uri(SandBox ? "https://api.sgroup.qq.com/" : "https://api.sgroup.qq.com/");
        }
        #endregion
        #region 构造函数
        public ChannelBotInfo(string appId, string token, int intents, bool sandBox)
        {
            AppId = appId;
            Token = token;
            Intents = intents;
            SandBox = sandBox;
        }
        public ChannelBotInfo(string appId, string token) : this(appId, token, (int)Enumerations.Intents.GUILDS, false)
        {

        }
        public ChannelBotInfo(string appId, string token, bool sandBox) : this(appId, token, (int)Enumerations.Intents.GUILDS, sandBox)
        {

        }
        #endregion
        /// <summary>
        /// 带有intents
        /// </summary>
        /// <param name="intents"><see cref="Intents"/>列表</param>
        /// <returns>添加完intents的<see cref="ChannelBotInfo"/></returns>
        public ChannelBotInfo WithIntents(IEnumerable<Intents> intents)
        {
            foreach (Intents intent in intents)
            {
                Intents |= (int)intent;
            }
            return this;
        }
    }
}
