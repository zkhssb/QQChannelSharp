using System.Threading.Channels;

namespace QQGuildBotFunc.WebSocket
{
    public class ChanManager<T>
    {
        private readonly Channel<T> _channel;
        public override int GetHashCode()
        {
            return _channel.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return _channel.Equals(obj);
        }
        public ChanManager(int capacity)
        {
            _channel = Channel.CreateBounded<T>(new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleReader = true,
                SingleWriter = false
            });
        }
        public async Task WriteAsync(T item, CancellationToken? token = null)
        {
            await _channel.Writer.WriteAsync(item, token ?? CancellationToken.None);
        }
        public async Task<T> ReadAsync(CancellationToken? token = null)
        {
            return await _channel.Reader.ReadAsync(token ?? CancellationToken.None);
        }
    }
}
