using QQChannelSharp.Attributes;
using QQChannelSharp.Dto.Pager;
using QQChannelSharp.Entities;
using QQChannelSharp.EventArgs;
using QQChannelSharp.Logger;
using QQChannelSharp.Segments;

namespace QQChannelSharp.Example.Handlers
{
    public class BotEventHandler
    {
        [EventHandler]
        public async ValueTask Ready(ReadyEvent data)
        {
            Log.LogInfo(data.Session.Id, $"[Handler]会话鉴权成功 {data.ReadyData.User.Username}");
            GuildPager pager = new();
            pager.WithLimit(100);
            var result = await data.OpenApi.MeGuildsAsync(pager);
            if (!result.IsSuccess) return;
            foreach (var channel in result.Result)
            {
                Console.WriteLine("频道名: {0} - {1}", channel.Name, channel.ID);
            }
        }

        [EventHandler]
        public async ValueTask MessageEvent(ATMessageEvent message)
        {
            var msg = new MessageBody();
            msg.Text("你好呀!");
            msg.Segment(Segment.At(message.Message.Author!.ID)); // AT消息发送者
            msg.Segment(Segment.Emoji(4)); // 添加一个Emoji ID为4
            msg.EndLine();
            msg.Text("你在");
            msg.Segment(Segment.Channel(message.Message.ChannelID));
            msg.Text("发送了一条消息");
            await message.Context.ReplyMessageAsync(msg);
        }
    }
}