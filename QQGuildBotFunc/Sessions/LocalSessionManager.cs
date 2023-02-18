using QQGuildBotFunc.Client;
using QQGuildBotFunc.Dto.WebSocket;
using QQGuildBotFunc.Exceptions;
using QQGuildBotFunc.Utils;
using QQGuildBotFunc.WebSocket;
using System.Net.WebSockets;

namespace QQGuildBotFunc.Sessions;

/// <summary>
/// 基于管道实现的单机manager。
/// </summary>
public class LocalSessionManager
{
    /// <summary>
    /// 用于传递Session的管道
    /// </summary>
    private ChanManager<Session> _sessionChan = new(1);
    private TimeSpan _startInterval = TimeSpan.FromSeconds(5);
    private CancellationTokenSource _handleCancellationTokenSource = new();
    private Task? _sessionTask;
    public async Task Start(WebsocketAP apInfo, GuildBotInfo botInfo)
    {
        _startInterval = SessionManagerUtils.CalcInterval(apInfo.SessionStartLimit.MaxConcurrency);
        // 按照shards数量初始化，用于启动连接的管理
        _sessionChan = new(apInfo.Shards);
        // 必须先启动处理器
        _sessionTask = SessionHandler(_handleCancellationTokenSource.Token);
        for (int i = 0; i < apInfo.Shards; i++)
        {
            await _sessionChan.WriteAsync(new Session()
            {
                BotInfo = botInfo,
                Intent = botInfo.Intents,
                Id = string.Empty,
                LastSeq = 0,
                Url = apInfo.Url,
                Shard = new()
                {
                    ShardID = i,
                    ShardCount = apInfo.Shards
                }
            }, _handleCancellationTokenSource.Token); // 如果管道已满,就会阻塞,直到管道内有剩余空间后才会继续写
        }
    }
    private async Task SessionHandler(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            Session session = await _sessionChan.ReadAsync(token); // 阻塞,直到管道内有新的session
            await Task.Delay(_startInterval, token);
            token.ThrowIfCancellationRequested();
            _ = Task.Run(() => NewConnect(session)); // 在新的任务中启动session
        }
    }
    /// <summary>
    /// 启动一个新的连接
    /// </summary>
    private async Task NewConnect(Session session)
    {
        Console.WriteLine("connecting: {0}", session.Shard.ShardID);
        using WsClient wsClient = new(session);
        try
        {
            wsClient.Connect();
        }
        catch (WebSocketException ex)
        {
            Console.WriteLine("shard{0} connect error: {0}", session.Shard.ShardID, ex.WebSocketErrorCode.ToString());
            await _sessionChan.WriteAsync(session); // 连接失败, 丢回去重新连接
        }
        //try
        //{
        if (string.IsNullOrWhiteSpace(session.Id)) // SessionId是空表示没有鉴权过,需要重新鉴权
            wsClient.Identify();
        else
            wsClient.Resume();
        int code = wsClient.Listening();
        if (code == -1) // -1 = NeedReConnect
        {
            await _sessionChan.WriteAsync(session); // 丢回去重新连接
        }
        else
        {
            if (SessionManagerUtils.CanNotIdentify(code))
                return; // 不能进行鉴权, 这里不再处理这个session 直接返回
            if (SessionManagerUtils.CanNotResume(code))
            {
                // 对于不能够进行重连的session，需要清空 session id 与 seq
                session.Id = string.Empty;
                session.LastSeq = 0;
            }
            await _sessionChan.WriteAsync(session); // 丢回去重新连接
        }
        //}
        /*
        catch (WebSocketClosedException ex)
        {
            if (SessionManagerUtils.CanNotIdentify(ex))
                return; // 不能进行鉴权, 这里不再处理这个session 直接返回
            if (SessionManagerUtils.CanNotResume(ex))
            {
                // 对于不能够进行重连的session，需要清空 session id 与 seq
                session.Id = string.Empty;
                session.LastSeq = 0;
            }
            await _sessionChan.WriteAsync(session); // 丢回去重新连接
        }
        catch (NeedReConnectException)
        {
            await _sessionChan.WriteAsync(session); // 丢回去重新连接
        }*/
    }
}