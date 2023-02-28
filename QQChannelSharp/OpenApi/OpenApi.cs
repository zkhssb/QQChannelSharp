using Microsoft.Extensions.Http;
using Polly;
using Polly.Contrib.WaitAndRetry;
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
using QQChannelSharp.Interfaces;

namespace QQChannelSharp.OpenApi
{
    public sealed class OpenApi : IOpenApi, IDisposable
    {
        public Task<PinsMessage> AddPinsAsync(string channelId, string messageId)
        {
            throw new NotImplementedException();
        }

        public Task<Permissions> ChannelPermissionsAsync(string channelId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ChannelRolesPermissions> ChannelRolesPermissionsAsync(string channelId, string roleId)
        {
            throw new NotImplementedException();
        }

        public Task CleanChannelAnnouncesAsync(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task CleanGuildAnnouncesAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task CleanPinsAsync(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<Announces> CreateChannelAnnouncesAsync(string channelId, GuildAnnouncesToCreate announce)
        {
            throw new NotImplementedException();
        }

        public Task<DirectMessage> CreateDirectMessageAsync(DirectMessageToCreate directMessage)
        {
            throw new NotImplementedException();
        }

        public Task<Announces> CreateGuildAnnouncesAsync(string guildId, GuildAnnouncesToCreate announces)
        {
            throw new NotImplementedException();
        }

        public Task CreateMessageReactionAsync(string channelId, string messageId, Emoji emoji)
        {
            throw new NotImplementedException();
        }

        public Task<Channel> CreatePrivateChannelAsync(string guildId, ChannelValueObject channel, IEnumerable<string> userId)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> CreateScheduleAsync(string channelId, Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task DeleteChannelAnnouncesAsync(string channelId, string messageId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteChannelAsync(string guildId, string channelId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGuildAnnouncesAsync(string guildId, string messageId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGuildMemberAsync(string guildId, string userId, MemberDeleteOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOwnMessageReaction(string channelId, string messageId, Emoji emoji)
        {
            throw new NotImplementedException();
        }

        public Task DeletePinsAsync(string channelId, string messageId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoleAsync(string guildId, string roleId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteScheduleAsync(string channelId, string scheduleId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Channel> GetChannelAsync(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Channel>> GetChannelsAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task<Guild> GetGuildAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task<Member> GetGuildMemberAsync(string guildId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Member>> GetGuildMembersAsync(string guildId, GuildMembersPager pager)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReactionUsers> GetMessageReactionUsersAsync(string channelId, string messageId, Emoji emoji, MessageReactionPager pager)
        {
            throw new NotImplementedException();
        }

        public Task<MessageSetting> GetMessageSettingAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task<APIPermissions> GetPermissionAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task<PinsMessage> GetPinsAsync(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<GuildRoles> GetRolesAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> GetScheduleAsync(string channelId, string scheduleId)
        {
            throw new NotImplementedException();
        }

        public Task GuildMuteAsync(string guildId, UpdateGuildMute mute)
        {
            throw new NotImplementedException();
        }

        public Task<List<Schedule>> ListSchedulesAsync(string channelId, long since)
        {
            throw new NotImplementedException();
        }

        public Task<List<Member>> ListVoiceChannelMembersAsync(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<User> MeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Guild>> MeGuildsAsync(GuildPager pager)
        {
            throw new NotImplementedException();
        }

        public Task MemberAddRoleAsync(string guildId, string roleId, string userId, MemberAddRoleBody value)
        {
            throw new NotImplementedException();
        }

        public Task MemberDeleteRoleAsync(string guildId, string roleId, string userId, MemberAddRoleBody value)
        {
            throw new NotImplementedException();
        }

        public Task MemberMuteAsync(string guildId, string userId, UpdateGuildMute mute)
        {
            throw new NotImplementedException();
        }

        public Task<Message> MessageAsync(string channelId, string messageId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> MessagesAsync(string channelId, MessagesPager pager)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> ModifyScheduleAsync(string channelId, string scheduleId, Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateGuildMuteResponse> MultiMemberMuteAsync(string guildId, UpdateGuildMute mute)
        {
            throw new NotImplementedException();
        }

        public Task<Channel> PatchChannelAsync(string guildId, ChannelValueObject channel)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateResult> PatchRoleAsync(string guildId, string roleId, Role role)
        {
            throw new NotImplementedException();
        }

        public Task<AudioControl> PostAudio(string channelId, AudioControl audioControl)
        {
            throw new NotImplementedException();
        }

        public Task<Channel> PostChannelAsync(string guildId, ChannelValueObject channel)
        {
            throw new NotImplementedException();
        }

        public Task<Message> PostDirectMessageAsync(DirectMessage directMessage, MessageToCreate message)
        {
            throw new NotImplementedException();
        }

        public Task<Message> PostDMSettingGuideAsync(DirectMessage directMessage, string jumpGuildId)
        {
            throw new NotImplementedException();
        }

        public Task<Message> PostMessageAsync(string channelId, MessageToCreate message)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateResult> PostRoleAsync(string guildId, Role role)
        {
            throw new NotImplementedException();
        }

        public Task<Message> PostSettingGuideAsync(string channelId, IEnumerable<string> atUserId)
        {
            throw new NotImplementedException();
        }

        public Task PutChannelPermissionsAsync(string channelId, string userId, UpdateChannelPermissions channelPermissions)
        {
            throw new NotImplementedException();
        }

        public Task PutChannelRolesPermissionsAsync(string channelId, string roleId, UpdateChannelPermissions channelPermissions)
        {
            throw new NotImplementedException();
        }

        public Task PutInteractionAsync(string interactionId, string body)
        {
            throw new NotImplementedException();
        }

        public Task<APIPermissionDemand> RequireAPIPermissions(string guildId, APIPermissionDemandToCreate demand)
        {
            throw new NotImplementedException();
        }

        public Task RetractDMMessageAsync(string guildId, string messageId, IEnumerable<RetractMessageOption>? options = null)
        {
            throw new NotImplementedException();
        }

        public Task RetractMessageAsync(string channelId, string messageId, IEnumerable<RetractMessageOption>? options = null)
        {
            throw new NotImplementedException();
        }

        public string TraceID()
        {
            throw new NotImplementedException();
        }

        public int Version()
        {
            throw new NotImplementedException();
        }
    }
}
