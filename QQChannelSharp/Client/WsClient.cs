using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Enumerations;
using QQChannelSharp.Exceptions;
using QQChannelSharp.Extensions;
using QQChannelSharp.WebSocket;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace QQChannelSharp.Client
{
    public class WsClient : IWebSocketClient
    {
        private bool _disposed;
        private Task? _heartbeatTask;
        private Task? _listeningTask;
        private readonly Session _session;
        private int _heartbeatInterval = 60 * 1000; // 默认值,后面会自动设置
        private byte[] _buffer = new byte[4096]; // _buffer

        public WsClient(Session session)
        {
            _session = session;
        }

        private readonly ClientWebSocket _webSocket = new();
        private readonly CancellationTokenSource _tokenSource = new();
        private readonly CancellationTokenSource _heartbeatTokenSource = new();

        public event WebSocketClosedAsyncCallBack? ClientClosed;

        /// <summary>
        /// 启动心跳
        /// </summary>
        /// <returns></returns>
        private async Task StartHeartBeat()
        {
            if (_heartbeatTask != null && _heartbeatTask.Status == TaskStatus.WaitingForActivation)
            {
                _heartbeatTokenSource.CancelAfter(TimeSpan.FromSeconds(1));
                await _heartbeatTask; // 等待任务结束
                _heartbeatTask.Dispose();
                _heartbeatTask = null;
            }
            _heartbeatTask = Task.Run(async () =>
            {
                try
                {
                    while (!_heartbeatTokenSource.IsCancellationRequested && _webSocket.State == WebSocketState.Open)
                    {
                        Write(new WebSocketPayload()
                        {
                            OPCode = OPCode.WSHeartbeat,
                            Data = _session.LastSeq
                        });
                        await Task.Delay(_heartbeatInterval, _heartbeatTokenSource.Token);
                    }
                }
                catch (WebSocketException) { } // 连接已经关闭
                catch (TaskCanceledException ex)
                {
                    ex.Task?.Dispose(); // 如果有Task,则必须销毁,否则TaskCanceledException会一直引用Task导致内存泄漏
                } // 任务取消
            });
        }
        public void Close()
        {
            // 销毁服务
            Dispose();
        }
        public void Connect()
        {
            if (string.IsNullOrWhiteSpace(_session.Url))
                throw new UrlInvalidException(_session);
            _webSocket.ConnectAsync(new Uri(_session.Url), CancellationToken.None).Wait();
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                _tokenSource.Cancel();


                if (_webSocket.State == WebSocketState.Open)
                    _webSocket
                        .CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None)
                        .Wait();

                _webSocket.Dispose();

                _heartbeatTokenSource.Cancel();
                if (null != _heartbeatTask && _heartbeatTask.Status == TaskStatus.WaitingForActivation)
                {
                    _heartbeatTask.Wait();
                }

                ClientClosed?.Invoke(_session, -1);

                //_listeningTask?.Dispose();
                _heartbeatTask?.Dispose();
                _heartbeatTokenSource.Dispose();
                _tokenSource.Dispose();
                GC.SuppressFinalize(this);
            }
        }
        public void Identify()
        {
            if (0 == _session.Intent) // 避免传错 intent
                _session.Intent = (int)Intents.GUILDS;
            Write(new WebSocketPayload()
            {
                OPCode = OPCode.WSIdentity,
                Data = new WSIdentityData()
                {
                    Token = _session.BotInfo.FullToken,
                    Intents = _session.Intent,
                    Shard = new int[2]
                    {
                        _session.Shard.ShardID,
                        _session.Shard.ShardCount
                    },
                    Properties = Properties.Default
                }
            });
        }
        public void Resume()
        {
            if (0 == _session.Intent) // 避免传错 intent
                _session.Intent = (int)Intents.GUILDS;
            Write(new WebSocketPayload()
            {
                OPCode = OPCode.WSResume,
                Data = new WSResumeData()
                {
                    Token = _session.BotInfo.FullToken,
                    SessionID = _session.Id,
                    Seq = _session.LastSeq
                }
            });
        }
        public void Listening()
        {
            if (_listeningTask != null)
                throw new InvalidOperationException(); // _listeningTask已经启动
            _listeningTask = ListeningAsync();
        }
        private async Task ListeningAsync()
        {
            int errorCode = -1;
            // 开始监听数据
            while (!_tokenSource.IsCancellationRequested && _webSocket.State == WebSocketState.Open)
            {
                try
                {
                    using MemoryStream ms = new();
                    while (true)
                    {
                        var receiveResult = await _webSocket.ReceiveAsync(_buffer, _tokenSource.Token);
                        _tokenSource.Token.ThrowIfCancellationRequested();
                        if (receiveResult.Count >= 0)
                        {
                            if (receiveResult.MessageType == WebSocketMessageType.Text)
                            {
                                ms.Write(_buffer, 0, receiveResult.Count);
                            }
                        }
                        if (receiveResult.EndOfMessage)
                            break;
                    }
                    if (HandleMessage(Encoding.UTF8.GetString(ms.ToArray())))
                    {
                        errorCode = 4009; // 如果处理消息返回True 那么就是收到了需要重连的消息
                        ClientClosed?.Invoke(_session, errorCode); // 通知后退出
                        return;
                    }
                }
                catch (WebSocketException ex)
                {
                    errorCode = ex.ErrorCode;
                    break; // 跳出While
                }
                catch (TaskCanceledException ex)
                {
                    ex.Task?.Dispose(); // 如果有Task,则必须销毁,否则TaskCanceledException会一直引用Task导致内存泄漏
                    break; // 任务已取消, 跳出While
                }
            }
            ClientClosed?.Invoke(_session, errorCode); // 已取消 or 连接已断开但是不知道原因
        }

        public Session Session()
            => _session;

        public void Write(WebSocketPayload payload)
        {
            string dataJson = JsonSerializer.Serialize(payload);
            try
            {
                _webSocket
                    .SendAsync(Encoding.UTF8.GetBytes(dataJson), WebSocketMessageType.Text, true, _tokenSource.Token)
                    .Wait();
            }
            catch (TaskCanceledException) { }
            Console.WriteLine("SEND: {0}", dataJson);
        }

        /// <summary>
        /// 处理内部消息
        /// </summary>
        /// <param name="msg">消息纯文本</param>
        /// <returns>如果需要关闭连接,则返回True</returns>
        private bool HandleMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return false;
            Console.WriteLine("{0}_WS: {1}", _session.Id, message);
            WebSocketPayload payload = JsonSerializer.Deserialize<WebSocketPayload>(message)
                ?? throw new ArgumentException("无法解析Payload");
            payload.RawMessage = message;
            SaveSeq(payload.Seq);
            switch (payload.OPCode)
            {
                case OPCode.WSReconnect:
                    return true; // 返回True,断开连接并重连
                case OPCode.WSDispatchEvent:
                    HandleDispatch(payload);
                    break;
                case OPCode.WSHello:
                    WSHelloData helloData = payload.GetData<WSHelloData>();
                    _heartbeatInterval = helloData.HeartbeatInterval;
                    StartHeartBeat().Wait(); // 启动心跳
                    break;
                default:
                    break;
            }
            return false;
        }

        private void SaveSeq(int seq)
        {
            if (seq > 0)
                _session.LastSeq = seq;
        }
        private void HandleDispatch(WebSocketPayload payload)
        {
            if (payload.OPCode is not OPCode.WSDispatchEvent)
                return;

            switch (payload.EventType)
            {
                case "READY":
                    var ready = payload.GetData<WSReadyData>();
                    _session.Id = ready.SessionID;
                    break;
                default:
                    break;
            }
        }

    }
}
