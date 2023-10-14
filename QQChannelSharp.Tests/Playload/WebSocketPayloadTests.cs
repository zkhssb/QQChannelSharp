using QQChannelSharp.Dto.Message;
using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Extensions;
using System.Text.Json;

namespace QQChannelSharp.Tests.Payload
{
    [TestClass]
    public class WebSocketPayloadTests
    {
        [TestMethod]
        public void PayloadMessageReactionTest()
        {
            var payload = JsonSerializer.Deserialize<WebSocketPayload>("""
{
    "op":0,
    "s":2,
    "t":"MESSAGE_REACTION_ADD",
    "id":"MESSAGE_REACTION_ADD:50dc07ea-4a3b-4634-8516-cf1e8ddfbf38",
    "d":{
        "channel_id":"454677820",
        "emoji":{
            "id":"89",
            "type":1
        },
        "guild_id":"5233096270906057162",
        "target":{
            "id":"08cac39bf6d0aaeccf4810bcaae7d801380248cee6f8a406",
            "type":"ReactionTargetType_MSG"
        },
        "user_id":"11528069550601428493"
    }
}
""");
            Assert.IsNotNull(payload);
            var reaction = payload.GetData<MessageReaction>();
            Assert.IsTrue(reaction.Target.Type == Enumerations.ReactionTargetType.Msg);
        }
    }
}
