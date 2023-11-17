using QQChannelSharp.Client;
using System.Net.Sockets;
using System.Net.WebSockets;

namespace QQChannelSharp.Tests;
[TestClass]
public class WsClientTests
{
    [TestMethod]
    public async Task WebSocketClientErrorTest()
    {
        WsClient client = new(new()
        {
            BotInfo = new("", "", true),
            Guid = Guid.NewGuid(),
            Id = "",
            Intent = 1,
            LastSeq = 0,
            Shard = new() { ShardID = 0 },
            Url = "wss://这就是个不存在的地址.com/"
        });
        await Assert.ThrowsExceptionAsync<WebSocketException>(client.ConnectAsync);
    }
}
