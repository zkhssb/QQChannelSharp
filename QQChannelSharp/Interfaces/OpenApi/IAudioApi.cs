using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Audio;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 音频接口
    /// </summary>
    public interface IAudioApi
    {
        /// <summary>
        /// 执行音频播放，暂停等操作
        /// <br/>
        /// 目前服务端成功不回包
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="audioControl">音频控制对象</param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> PostAudioAsync(string channelId, AudioControl audioControl);
    }
}
