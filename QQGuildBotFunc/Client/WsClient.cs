using QQGuildBotFunc.Dto.Message;
using QQGuildBotFunc.Dto.WebSocket;
using QQGuildBotFunc.Enumerations;
using QQGuildBotFunc.Exceptions;
using QQGuildBotFunc.Extensions;
using QQGuildBotFunc.WebSocket;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace QQGuildBotFunc.Client
{
    public class WsClient : IWebSocketClient
    {
        private Session _session;
        private ClientWebSocket? _webSocket;
        private ChanManager<int> _closeChan;
        private ChanManager<int> _resumeChan;
        public ChanManager<string> _messageChan;
        private CancellationTokenSource? _recvCancellationTokenSource;
        private CancellationTokenSource? _heartCancellationTokenSource;
        private Task? _readTask;
        private Task? _handleTask;
        private Task? _heartTask;

        // 收到Hello包后会重置
        private int _heartbeatInterval = 60 * 1000;
        public WsClient(Session session)
        {
            _session = session;
            _resumeChan = new(1);
            _closeChan = new(1);
            _messageChan = new(1);
        }
        public void Close()
        {
            if (_recvCancellationTokenSource is not null) // 取消读取/处理 (ReadMessage/HandleMessage)
            {
                _recvCancellationTokenSource.Cancel();
                _recvCancellationTokenSource = null;
            }
            if (_heartCancellationTokenSource is not null) // 取消心跳
            {
                _heartCancellationTokenSource.Cancel();
                _heartCancellationTokenSource = null;
            }
            if (_webSocket is not null && _webSocket.State is WebSocketState.Open)
            {
                _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None).Wait();
            }
        }
        /// <summary>
        /// Connect 连接到 websocket
        /// </summary>
        /// <exception cref="UrlInvalidException">Session中的Url是空</exception>
        public void Connect()
        {
            if (string.IsNullOrWhiteSpace(_session.Url))
                throw new UrlInvalidException(_session);
            Close();
            _webSocket = new();
            _webSocket.ConnectAsync(new Uri(_session.Url), CancellationToken.None)
                .Wait();
            if (_recvCancellationTokenSource is not null)
            {
                _recvCancellationTokenSource.Cancel();
                _recvCancellationTokenSource.Dispose();
                _recvCancellationTokenSource = null;
            }
            _recvCancellationTokenSource = new CancellationTokenSource();
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
        public int Listening()
        {
            if (_webSocket is null
                || _webSocket.State != WebSocketState.Open
                || _recvCancellationTokenSource is null                     // 只要调用了 Connect 就不可能为Null
                || _recvCancellationTokenSource.IsCancellationRequested)
                throw new InvalidOperationException();
            try
            {
                // 开始读取数据
                _readTask?.Dispose();
                _readTask = ReadMessage(_recvCancellationTokenSource.Token);

                // 开始处理数据
                _handleTask?.Dispose();
                _handleTask = HandleMessage(_recvCancellationTokenSource.Token);

                // 等待重连请求或连接关闭请求
                var resumeTask = _resumeChan.ReadAsync();
                var closeTask = _closeChan.ReadAsync();
                var completedTask = Task.WaitAny(new Task[]
                {
                    resumeTask,
                    closeTask,
                });
                switch (completedTask)
                {
                    case 0: // resumeTask
                        return -1;
                    // throw new NeedReConnectException(_session);
                    case 1: // closeTask
                        return closeTask.Result;
                    //throw new WebSocketClosedException(_session, closeTask.Result);
                    default:
                        return 0;
                }
            }
            finally
            {
                Close();
                _webSocket?.Dispose();
                _webSocket = null;
            }
        }
        private async Task ReadMessage(CancellationToken token)
        {
            byte[] buffer = new byte[1024];
            try
            {
                while (_webSocket is not null
                    && _webSocket.State == WebSocketState.Open
                    && !token.IsCancellationRequested)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        while (true)
                        {
                            var result = await _webSocket.ReceiveAsync(buffer, _recvCancellationTokenSource?.Token ?? CancellationToken.None);
                            if (result.MessageType == WebSocketMessageType.Text)
                            {
                                ms.Write(buffer, 0, result.Count);
                            }
                            else if (result.MessageType == WebSocketMessageType.Close)
                            {
                                if (result.CloseStatus is not null)
                                {
                                    int value = (int)result.CloseStatus.Value;
                                    if (value == 4009) // 4009	连接过期，请重连并执行 resume 进行重新连接
                                        await _resumeChan.WriteAsync(4009, token);
                                    else
                                        await _closeChan.WriteAsync((int)result.CloseStatus.Value, token);
                                }
                                else
                                    await _closeChan.WriteAsync(-1, token);
                                return;
                            }
                            if (result.EndOfMessage)
                                break;
                        }
                        await _messageChan.WriteAsync(Encoding.UTF8.GetString(ms.ToArray()), token);
                        //await HandleMessage(Encoding.UTF8.GetString(ms.ToArray()));
                        //Console.WriteLine("WS: {0}", Encoding.UTF8.GetString(ms.ToArray()));
                    }
                }
            }
            catch (WebSocketException e)
            {
                await _resumeChan.WriteAsync(e.ErrorCode, token);
                return;
            }
        }
        /// <summary>
        /// 内部消息处理
        /// </summary>
        private async Task HandleMessage(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    string message = await _messageChan.ReadAsync();
                    if (string.IsNullOrWhiteSpace(message))
                        return;
                    Console.WriteLine("{0}_WS: {1}", _session.Id, message);
                    WebSocketPayload payload = JsonSerializer.Deserialize<WebSocketPayload>(message)
                        ?? throw new ArgumentException("无法解析Payload");
                    payload.RawMessage = message;
                    SaveSeq(payload.Seq);
                    switch (payload.OPCode)
                    {
                        case OPCode.WSDispatchEvent:
                            HandleDispatch(payload);
                            break;
                        case OPCode.WSHeartbeat:
                            break;
                        case OPCode.WSIdentity:
                            break;
                        case OPCode.WSResume:
                            break;
                        case OPCode.WSReconnect:
                            Close();
                            await _resumeChan.WriteAsync(4009); // 立刻进行重连
                            break;
                        case OPCode.WSInvalidSession:
                            break;
                        case OPCode.WSHello:
                            WSHelloData helloData = payload.GetData<WSHelloData>();
                            _heartbeatInterval = helloData.HeartbeatInterval;

                            // 重置心跳
                            _heartCancellationTokenSource?.Cancel();
                            _heartCancellationTokenSource?.Dispose();
                            _heartCancellationTokenSource = new();
                            _heartTask?.Dispose();
                            _heartTask = HeartBeat(_heartCancellationTokenSource.Token);
                            break;
                        case OPCode.WSHeartbeatAck:
                            break;
                        case OPCode.HTTPCallbackAck:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
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
        private async Task HeartBeat(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                    Write(new WebSocketPayload()
                    {
                        OPCode = OPCode.WSHeartbeat,
                        Data = _session.LastSeq
                    });
                    await Task.Delay(_heartbeatInterval, token);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
        private void SaveSeq(int seq)
        {
            if (seq > 0)
                _session.LastSeq = seq;
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
        public Session Session()
            => _session;
        public void Write(WebSocketPayload payload)
        {
            string dataJson = JsonSerializer.Serialize(payload);
            Console.WriteLine("SEND: {0}", dataJson);
            if (_webSocket is not null)
                _webSocket.SendAsync(Encoding.UTF8.GetBytes(dataJson), WebSocketMessageType.Text, true, CancellationToken.None).Wait();
        }
        public void Dispose()
        {
            Close();
        }
    }
}
