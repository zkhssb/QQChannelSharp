using QQChannelSharp.Enumerations;

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
        public ChannelBotInfo(string appId, string token, bool sandBox)
        {
            AppId = appId;
            Token = token;
            SandBox = sandBox;
        }
        public ChannelBotInfo(string appId, string token) : this(appId, token, false)
        {

        }
        #endregion
    }
}
