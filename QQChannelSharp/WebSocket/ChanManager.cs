using System.Threading.Channels;

namespace QQChannelSharp.WebSocket
{
    /// <summary>
    /// 管道管理器
    /// </summary>
    public class ChanManager<T> : IDisposable
    {
        private readonly Channel<T> _channel;
        private bool _disposed;

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
            ThrowIfDisposed();
            await _channel.Writer.WriteAsync(item, token ?? CancellationToken.None);
        }

        public async Task<T> ReadAsync(CancellationToken? token = null)
        {
            ThrowIfDisposed();
            return await _channel.Reader.ReadAsync(token ?? CancellationToken.None);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _channel.Writer.Complete();
                while (_channel.Reader.TryRead(out _))
                {
                    // do nothing
                }
                _disposed = true;
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }
}