using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Announce;
using QQChannelSharp.Dto.ApiPermissions;
using QQChannelSharp.Dto.Audio;
using QQChannelSharp.Dto.ChannelPermissions;
using QQChannelSharp.Dto.Channels;
using QQChannelSharp.Dto.Direct;
using QQChannelSharp.Dto.Members;
using QQChannelSharp.Dto.Message;
using QQChannelSharp.Dto.Messages;
using QQChannelSharp.Dto.Mute;
using QQChannelSharp.Dto.Options;
using QQChannelSharp.Dto.Pager;
using QQChannelSharp.Dto.Roles;
using QQChannelSharp.Dto.Schedules;
using QQChannelSharp.Enumerations;
using QQChannelSharp.Extensions;
using QQChannelSharp.Interfaces;
using RestSharp;
using Channel = QQChannelSharp.Dto.Channels.Channel;

namespace QQChannelSharp.OpenApi
{
    public sealed class OpenApi : IOpenApi
    {
        private readonly HttpClient _httpClient;
        private readonly RestClient _restClient;
        private readonly ChannelBotInfo _channelBotInfo;

        public OpenApi(RestClient restClient, HttpClient httpClient, ChannelBotInfo botInfo)
        {
            _httpClient = httpClient;
            _restClient = restClient;
            _channelBotInfo = botInfo;
        }

        public async Task<HttpResult<PinsMessage>> AddPinsAsync(string channelId, string messageId)
        {
            var request = new RestRequest("/channels/{channel_id}/pins/{message_id}", Method.Put)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("message_id", messageId);
            return await _restClient.ExecAsync<PinsMessage>(request);
        }

        public async Task<HttpResult<Permissions>> ChannelPermissionsAsync(string channelId, string userId)
        {
            var request = new RestRequest("/channels/{channel_id}/members/{user_id}/permissions", Method.Get)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("user_id", userId);
            return await _restClient.ExecAsync<Permissions>(request);
        }

        public async Task<HttpResult<ChannelRolesPermissions>> ChannelRolesPermissionsAsync(string channelId, string roleId)
        {
            var request = new RestRequest("/channels/{channel_id}/roles/{role_id}/permissions", Method.Get)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("role_id", roleId);
            return await _restClient.ExecAsync<ChannelRolesPermissions>(request);
        }

        public async Task<HttpResult<EmptyObject>> CleanChannelAnnouncesAsync(string channelId)
        {
            var request = new RestRequest("/channels/{channel_id}/announces/{message_id}", Method.Delete)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("message_id", "all");
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> CleanGuildAnnouncesAsync(string guildId)
        {
            var request = new RestRequest("/guilds/{guild_id}/announces/{message_id}", Method.Delete)
                .AddUrlSegment("guild_id", guildId)
                .AddUrlSegment("message_id", "all");
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> CleanPinsAsync(string channelId)
        {
            //return await DeletePinsAsync(channelId, "all");
            var request = new RestRequest("/channels/{channel_id}/pins/{message_id}", Method.Delete)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("message_id", "all");
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<Announces>> CreateChannelAnnouncesAsync(string channelId, GuildAnnouncesToCreate announce)
        {
            var request = new RestRequest("/channels/{channel_id}/announces", Method.Post)
                .AddUrlSegment("channel_id", channelId)
                .AddJsonBody(announce);
            return await _restClient.ExecAsync<Announces>(request);
        }

        public async Task<HttpResult<DirectMessage>> CreateDirectMessageAsync(DirectMessageToCreate directMessage)
        {
            var request = new RestRequest("/users/@me/dms", Method.Post)
                .AddJsonBody(directMessage);
            return await _restClient.ExecAsync<DirectMessage>(request);
        }

        public async Task<HttpResult<Announces>> CreateGuildAnnouncesAsync(string guildId, GuildAnnouncesToCreate announces)
        {
            var request = new RestRequest("/guilds/{guild_id}/announces", Method.Post)
                .AddUrlSegment("guild_id", guildId)
                .AddJsonBody(announces);
            return await _restClient.ExecAsync<Announces>(request);
        }

        public async Task<HttpResult<EmptyObject>> CreateMessageReactionAsync(string channelId, string messageId, Emoji emoji)
        {
            var request = new RestRequest("/channels/{channel_id}/messages/{message_id}/reactions/{emoji_type}/{emoji_id}", Method.Put)
                 .AddUrlSegment("channel_id", channelId)
                 .AddUrlSegment("message_id", messageId)
                 .AddUrlSegment("emoji_id", emoji.ID.ToString())
                 .AddUrlSegment("emoji_type", emoji.Type.ToString());
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<Channel>> CreatePrivateChannelAsync(string guildId, ChannelValueObject channel, IEnumerable<string> userId)
        {
            channel.PrivateType = ChannelPrivateType.AdminAndMember;
            string[] ids = userId.ToArray();
            if (ids.Length != 0)
            {
                channel.PrivateUserIDs = userId.ToArray();
                channel.PrivateType = ChannelPrivateType.OnlyAdmin;
            }
            return await PostChannelAsync(guildId, channel);
        }

        public async Task<HttpResult<Schedule>> CreateScheduleAsync(string channelId, Schedule schedule)
        {

            ScheduleWrapper body = new()
            {
                Schedule = schedule
            };

            var request = new RestRequest("/channels/{channel_id}/schedules", Method.Post)
                .AddUrlSegment("channel_id", channelId)
                .AddBody(body);

            return await _restClient.ExecAsync<Schedule>(request);
        }

        public async Task<HttpResult<EmptyObject>> DeleteChannelAnnouncesAsync(string channelId, string messageId)
        {
            var request = new RestRequest("/channels/{channel_id}/announces/{message_id}", Method.Delete)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("message_id", messageId);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> DeleteChannelAsync(string channelId)
        {
            var request = new RestRequest("/channels/{channel_id}", Method.Delete)
                .AddUrlSegment("channel_id", channelId);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> DeleteGuildAnnouncesAsync(string guildId, string messageId)
        {
            var request = new RestRequest("/guilds/{guild_id}/announces/{message_id}", Method.Delete)
                .AddUrlSegment("guild_id", guildId)
                .AddUrlSegment("message_id", messageId);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> DeleteGuildMemberAsync(string guildId, string userId, MemberDeleteOptions? options = null)
        {
            var request = new RestRequest("/guilds/{guild_id}/members/{user_id}", Method.Delete)
                .AddUrlSegment("guild_id", guildId)
                .AddUrlSegment("user_id", userId)
                .AddJsonBody(options ?? new());
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> DeleteOwnMessageReaction(string channelId, string messageId, Emoji emoji)
        {
            var request = new RestRequest("/channels/{channel_id}/messages/{message_id}/reactions/{emoji_type}/{emoji_id}", Method.Delete)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("message_id", messageId)
                .AddUrlSegment("emoji_type", emoji.Type.ToString())
                .AddUrlSegment("emoji_id", emoji.ID.ToString());
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> DeletePinsAsync(string channelId, string messageId)
        {
            var request = new RestRequest("/channels/{channel_id}/pins/{message_id}", Method.Delete)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("message_id", messageId);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> DeleteRoleAsync(string guildId, string roleId)
        {
            var request = new RestRequest("/guilds/{guild_id}/roles/{role_id}", Method.Delete)
               .AddUrlSegment("guild_id", guildId)
               .AddUrlSegment("role_id", roleId);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> DeleteScheduleAsync(string channelId, string scheduleId)
        {
            var request = new RestRequest("/channels/{channel_id}/schedules/{schedule_id}", Method.Delete)
               .AddUrlSegment("channel_id", channelId)
               .AddUrlSegment("schedule_id", scheduleId);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<Channel>> GetChannelAsync(string channelId)
        {
            var request = new RestRequest("/channels/{channel_id}", Method.Get)
                .AddUrlSegment("channel_id", channelId);
            return await _restClient.ExecAsync<Channel>(request);
        }

        public async Task<HttpResult<List<Channel>>> GetChannelsAsync(string guildId)
        {
            var request = new RestRequest("/guilds/{guild_id}/channels", Method.Get)
                .AddUrlSegment("guild_id", guildId);
            return await _restClient.ExecAsync<List<Channel>>(request);
        }

        public async Task<HttpResult<Guild>> GetGuildAsync(string guildId)
        {
            var request = new RestRequest("/guilds/{guild_id}", Method.Get)
                  .AddUrlSegment("guild_id", guildId);
            return await _restClient.ExecAsync<Guild>(request);
        }

        public async Task<HttpResult<Member>> GetGuildMemberAsync(string guildId, string userId)
        {
            var request = new RestRequest("/guilds/{guild_id}/members/{user_id}", Method.Get)
                  .AddUrlSegment("guild_id", guildId)
                  .AddUrlSegment("user_id", userId);
            return await _restClient.ExecAsync<Member>(request);
        }

        public async Task<HttpResult<List<Member>>> GetGuildMembersAsync(string guildId, GuildMembersPager pager)
        {
            var request = new RestRequest("/guilds/{guild_id}/members", Method.Get)
                 .AddUrlSegment("guild_id", guildId)
                 .AddQueryParameter(pager.QueryParams());
            return await _restClient.ExecAsync<List<Member>>(request);
        }

        public async Task<HttpResult<MessageReactionUsers>> GetMessageReactionUsersAsync(string channelId, string messageId, Emoji emoji, MessageReactionPager pager)
        {
            var request = new RestRequest("/channels/{channel_id}/messages/{message_id}/reactions/{emoji_type}/{emoji_id}", Method.Get)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("message_id", messageId)
                .AddUrlSegment("emoji_type", emoji.Type.ToString())
                .AddUrlSegment("emoji_id", emoji.ID.ToString())
                .AddQueryParameter(pager.ToQueryParams());
            return await _restClient.ExecAsync<MessageReactionUsers>(request);
        }

        public async Task<HttpResult<MessageSetting>> GetMessageSettingAsync(string guildId)
        {
            var request = new RestRequest("/guilds/{guild_id}/message/setting", Method.Get)
                .AddUrlSegment("guild_id", guildId);
            return await _restClient.ExecAsync<MessageSetting>(request); ;
        }

        public async Task<HttpResult<APIPermissions>> GetPermissionAsync(string guildId)
        {
            var request = new RestRequest("/guilds/{guild_id}/api_permission", Method.Get)
                .AddUrlSegment("guild_id", guildId);
            return await _restClient.ExecAsync<APIPermissions>(request);
        }

        public async Task<HttpResult<PinsMessage>> GetPinsAsync(string channelId)
        {
            var request = new RestRequest("/channels/{channel_id}/pins", Method.Get)
                .AddUrlSegment("channel_id", channelId);
            return await _restClient.ExecAsync<PinsMessage>(request);
        }

        public async Task<HttpResult<GuildRoles>> GetRolesAsync(string guildId)
        {
            var request = new RestRequest("/guilds/{guild_id}/roles", Method.Get)
                .AddUrlSegment("guild_id", guildId);
            return await _restClient.ExecAsync<GuildRoles>(request);
        }

        public async Task<HttpResult<Schedule>> GetScheduleAsync(string channelId, string scheduleId)
        {
            var request = new RestRequest("/channels/{channel_id}/schedules/{schedule_id}", Method.Get)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("schedule_id", scheduleId);
            return await _restClient.ExecAsync<Schedule>(request);
        }

        public async Task<HttpResult<EmptyObject>> GuildMuteAsync(string guildId, UpdateGuildMute mute)
        {
            var request = new RestRequest("/guilds/{guild_id}/mute", Method.Patch)
               .AddUrlSegment("guild_id", guildId)
               .AddJsonBody(mute);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<List<Schedule>>> ListSchedulesAsync(string channelId, long since)
        {
            var request = new RestRequest("/channels/{channel_id}/schedules", Method.Get)
                .AddUrlSegment("channel_id", channelId)
                .AddQueryParameter("since", since.ToString());
            return await _restClient.ExecAsync<List<Schedule>>(request);
        }

        public async Task<HttpResult<List<Member>>> ListVoiceChannelMembersAsync(string channelId)
        {
            var request = new RestRequest("/channels/{channel_id}/voice/members", Method.Get)
                .AddUrlSegment("channel_id", channelId);
            return await _restClient.ExecAsync<List<Member>>(request);
        }

        public async Task<HttpResult<User>> MeAsync()
        {
            var request = new RestRequest("/users/@me", Method.Get);
            return await _restClient.ExecAsync<User>(request);
        }

        public async Task<HttpResult<List<Guild>>> MeGuildsAsync(GuildPager pager)
        {
            var request = new RestRequest("/users/@me/guilds", Method.Get)
                .AddQueryParameter(pager.QueryParams());
            return await _restClient.ExecAsync<List<Guild>>(request);
        }

        public async Task<HttpResult<EmptyObject>> MemberAddRoleAsync(string guildId, string roleId, string userId, MemberAddRoleBody value)
        {
            var request = new RestRequest("/guilds/{guild_id}/members/{user_id}/roles/{role_id}", Method.Put)
                .AddUrlSegment("guild_id", guildId)
                .AddUrlSegment("user_id", roleId)
                .AddUrlSegment("user_id", userId)
                .AddJsonBody(value);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> MemberDeleteRoleAsync(string guildId, string roleId, string userId, MemberAddRoleBody value)
        {
            var request = new RestRequest("/guilds/{guild_id}/members/{user_id}/roles/{role_id}", Method.Delete)
                .AddUrlSegment("guild_id", guildId)
                .AddUrlSegment("user_id", roleId)
                .AddUrlSegment("user_id", userId)
                .AddJsonBody(value);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> MemberMuteAsync(string guildId, string userId, UpdateGuildMute mute)
        {
            var request = new RestRequest("/guilds/{guild_id}/members/{user_id}/mute", Method.Patch)
                .AddUrlSegment("guild_id", guildId)
                .AddUrlSegment("user_id", userId)
                .AddJsonBody(mute);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<Message>> MessageAsync(string channelId, string messageId)
        {
            var request = new RestRequest("/channels/{channel_id}/messages/{message_id}", Method.Get)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("message_id", messageId);
            return await _restClient.ExecAsync<Message>(request);
        }

        public async Task<HttpResult<List<Message>>> MessagesAsync(string channelId, MessagesPager pager)
        {
            var request = new RestRequest("/channels/{channel_id}/messages", Method.Get)
                .AddUrlSegment("channel_id", channelId)
                .AddQueryParameter(pager.QueryParams());
            return await _restClient.ExecAsync<List<Message>>(request);
        }

        public async Task<HttpResult<Schedule>> ModifyScheduleAsync(string channelId, string scheduleId, Schedule schedule)
        {
            ScheduleWrapper body = new()
            {
                Schedule = schedule
            };

            var request = new RestRequest("/channels/{channel_id}/schedules/{schedule_id}", Method.Patch)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("schedule_id", scheduleId)
                .AddJsonBody(body);
            return await _restClient.ExecAsync<Schedule>(request);
        }

        public async Task<HttpResult<UpdateGuildMuteResponse>> MultiMemberMuteAsync(string guildId, UpdateGuildMute mute)
        {
            if (mute.UserIDs?.Length == 0)
                throw new ArgumentNullException("no user id param");
            var request = new RestRequest("/guilds/{guild_id}/mute", Method.Patch)
                .AddUrlSegment("guild_id", guildId)
                .AddJsonBody(mute);
            return await _restClient.ExecAsync<UpdateGuildMuteResponse>(request);
        }

        public async Task<HttpResult<Channel>> PatchChannelAsync(string channelId, ChannelValueObject channel)
        {
            var request = new RestRequest("/channels/{channel_id}", Method.Patch)
                .AddUrlSegment("channel_id", channelId)
                .AddJsonBody(channel);
            return await _restClient.ExecAsync<Channel>(request);
        }

        public async Task<HttpResult<Message>> PatchMessageAsync(string channelId, string messageId, MessageToCreate message)
        {
            var request = new RestRequest("/channels/{channel_id}/messages/{message_id}", Method.Patch)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("message_id", messageId)
                .AddJsonBody(message);
            return await _restClient.ExecAsync<Message>(request);
        }

        public async Task<HttpResult<UpdateResult>> PatchRoleAsync(string guildId, string roleId, Role role)
        {
            Role roleClone = new Role()
            {
                Color = role.Color,
                Hoist = role.Hoist,
                Name = role.Name,
                MemberCount = role.MemberCount,
                MemberLimit = role.MemberLimit,
            };
            if (roleClone.Color == 0)
                roleClone.Color = 4278245297; // 用户组默认颜色值

            UpdateRoleFilter filter = new()
            {
                Name = 1,
                Color = 1,
                Hoist = 1,
            };

            UpdateRole body = new()
            {
                Filter = filter,
                GuildID = guildId,
                Update = roleClone
            };

            var request = new RestRequest("/guilds/{guild_id}/roles/{role_id}", Method.Patch)
                .AddUrlSegment("guild_id", guildId)
                .AddUrlSegment("role_id", roleId)
                .AddJsonBody(body);

            return await _restClient.ExecAsync<UpdateResult>(request);
        }

        public async Task<HttpResult<EmptyObject>> PostAudioAsync(string channelId, AudioControl audioControl)
        {
            // 目前服务端成功不回包
            var request = new RestRequest("/channels/{channel_id}/audio", Method.Post)
                .AddUrlSegment("channel_id", channelId)
                .AddJsonBody(audioControl);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<Channel>> PostChannelAsync(string guildId, ChannelValueObject channel)
        {
            var request = new RestRequest("/guilds/{guild_id}/channels", Method.Post)
                .AddUrlSegment("guild_id", guildId)
                .AddJsonBody(channel);
            return await _restClient.ExecAsync<Channel>(request);
        }

        public async Task<HttpResult<Message>> PostDirectMessageAsync(DirectMessage directMessage, MessageToCreate message)
        {
            var request = new RestRequest("/dms/{guild_id}/messages", Method.Post)
                .AddUrlSegment("guild_id", directMessage.GuildID)
                .AddJsonBody(message);
            return await _restClient.ExecAsync<Message>(request);
        }

        public async Task<HttpResult<Message>> PostDMSettingGuideAsync(DirectMessage directMessage, string jumpGuildId)
        {
            SettingGuideToCreate stc = new()
            {
                SettingGuide = new() { GuildID = jumpGuildId }
            };
            var request = new RestRequest("/dms/{guild_id}/settingguide", Method.Post)
                .AddUrlSegment("guild_id", directMessage.GuildID)
                .AddJsonBody(stc);
            return await _restClient.ExecAsync<Message>(request);
        }

        public async Task<HttpResult<Message>> PostMessageAsync(string channelId, MessageToCreate message)
        {
            var request = new RestRequest("/channels/{channel_id}/messages", Method.Post)
                  .AddUrlSegment("channel_id", channelId)
                  .AddJsonBody(message);
            return await _restClient.ExecAsync<Message>(request);
        }

        public async Task<HttpResult<UpdateResult>> PostRoleAsync(string guildId, Role role)
        {
            Role roleClone = new Role()
            {
                Color = role.Color,
                Hoist = role.Hoist,
                Name = role.Name,
                MemberCount = role.MemberCount,
                MemberLimit = role.MemberLimit,
            };
            if (roleClone.Color == 0)
                roleClone.Color = 4278245297; // 用户组默认颜色值

            UpdateRoleFilter filter = new()
            {
                Name = 1,
                Color = 1,
                Hoist = 1,
            };

            UpdateRole body = new()
            {
                Filter = filter,
                GuildID = guildId,
                Update = roleClone
            };

            var request = new RestRequest("/guilds/{guild_id}/roles", Method.Post)
                .AddUrlSegment("guild_id", guildId)
                .AddJsonBody(body);

            return await _restClient.ExecAsync<UpdateResult>(request);
        }

        public async Task<HttpResult<Message>> PostSettingGuideAsync(string channelId, IEnumerable<string> atUserId)
        {
            string atUsers = string.Empty;
            foreach (var userId in atUserId)
            {
                atUsers += $"<@{userId}>";
            }
            SettingGuideToCreate body = new()
            {
                Content = atUsers
            };
            var request = new RestRequest("/channels/{channel_id}/settingguide", Method.Post)
                .AddUrlSegment("channel_id", channelId)
                .AddJsonBody(body);
            return await _restClient.ExecAsync<Message>(request);
        }

        public async Task<HttpResult<EmptyObject>> PutChannelPermissionsAsync(string channelId, string userId, UpdateChannelPermissions channelPermissions)
        {
            if (!string.IsNullOrWhiteSpace(channelPermissions.Add) && !int.TryParse(channelPermissions.Add, out int _))
                throw new ArgumentException($"invalid parameter add: {channelPermissions.Add}");

            if (!string.IsNullOrWhiteSpace(channelPermissions.Remove) && !int.TryParse(channelPermissions.Add, out int _))
                throw new ArgumentException($"invalid parameter remove: {channelPermissions.Remove}");

            var request = new RestRequest("/channels/{channel_id}/members/{user_id}/permissions", Method.Put)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("user_id", userId)
                .AddJsonBody(channelPermissions);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> PutChannelRolesPermissionsAsync(string channelId, string roleId, UpdateChannelPermissions channelPermissions)
        {
            if (!string.IsNullOrWhiteSpace(channelPermissions.Add) && !int.TryParse(channelPermissions.Add, out int _))
                throw new ArgumentException($"invalid parameter add: {channelPermissions.Add}");

            if (!string.IsNullOrWhiteSpace(channelPermissions.Remove) && !int.TryParse(channelPermissions.Add, out int _))
                throw new ArgumentException($"invalid parameter remove: {channelPermissions.Remove}");

            var request = new RestRequest("/channels/{channel_id}/roles/{role_id}/permissions", Method.Put)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("role_id", roleId)
                .AddJsonBody(channelPermissions);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> PutInteractionAsync(string interactionId, string body)
        {
            var request = new RestRequest("/interactions/{interaction_id}", Method.Put)
                .AddUrlSegment("interaction_id", interactionId)
                .AddBody(body);
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<APIPermissionDemand>> RequireAPIPermissionsAsync(string guildId, APIPermissionDemandToCreate demand)
        {
            var request = new RestRequest("/guilds/{guild_id}/api_permission/demand", Method.Post)
                .AddUrlSegment("guild_id", guildId)
                .AddJsonBody(demand);
            return await _restClient.ExecAsync<APIPermissionDemand>(request);
        }

        public async Task<HttpResult<EmptyObject>> RetractDMMessageAsync(string guildId, string messageId, IEnumerable<RetractMessageOption>? options = null)
        {
            var request = new RestRequest("/dms/{guild_id}/messages/{message_id}", Method.Delete)
                .AddUrlSegment("guild_id", guildId)
                .AddUrlSegment("message_id", messageId);

            foreach (var option in options ?? new RetractMessageOption[0])
            {
                switch (option)
                {
                    case RetractMessageOption.Hidetip:
                        request.AddQueryParameter("hidetip", true);
                        break;
                    default:
                        break;
                }
            }
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public async Task<HttpResult<EmptyObject>> RetractMessageAsync(string channelId, string messageId, IEnumerable<RetractMessageOption>? options = null)
        {
            var request = new RestRequest("/channels/{channel_id}/messages/{message_id}", Method.Delete)
                .AddUrlSegment("channel_id", channelId)
                .AddUrlSegment("message_id", messageId);

            foreach (var option in options ?? new RetractMessageOption[0])
            {
                switch (option)
                {
                    case RetractMessageOption.Hidetip:
                        request.AddQueryParameter("hidetip", true);
                        break;
                    default:
                        break;
                }
            }
            return await _restClient.ExecAsync<EmptyObject>(request);
        }

        public void Dispose()
        {
            _restClient?.Dispose();
            _httpClient?.Dispose();
        }

        public int Version()
            => 1;
    }
}
