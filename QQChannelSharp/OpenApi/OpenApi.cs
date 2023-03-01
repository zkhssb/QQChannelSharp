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
    public sealed class OpenApi : IOpenApi
    {
        public Task<HttpResult<PinsMessage>> AddPinsAsync(string channelId, string messageId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Permissions>> ChannelPermissionsAsync(string channelId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<ChannelRolesPermissions>> ChannelRolesPermissionsAsync(string channelId, string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> CleanChannelAnnouncesAsync(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> CleanGuildAnnouncesAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> CleanPinsAsync(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Announces>> CreateChannelAnnouncesAsync(string channelId, GuildAnnouncesToCreate announce)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<DirectMessage>> CreateDirectMessageAsync(DirectMessageToCreate directMessage)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Announces>> CreateGuildAnnouncesAsync(string guildId, GuildAnnouncesToCreate announces)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> CreateMessageReactionAsync(string channelId, string messageId, Emoji emoji)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Channel>> CreatePrivateChannelAsync(string guildId, ChannelValueObject channel, IEnumerable<string> userId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Schedule>> CreateScheduleAsync(string channelId, Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> DeleteChannelAnnouncesAsync(string channelId, string messageId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> DeleteChannelAsync(string guildId, string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> DeleteGuildAnnouncesAsync(string guildId, string messageId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> DeleteGuildMemberAsync(string guildId, string userId, MemberDeleteOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> DeleteOwnMessageReaction(string channelId, string messageId, Emoji emoji)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> DeletePinsAsync(string channelId, string messageId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> DeleteRoleAsync(string guildId, string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> DeleteScheduleAsync(string channelId, string scheduleId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Channel>> GetChannelAsync(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<List<Channel>>> GetChannelsAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Guild>> GetGuildAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Member>> GetGuildMemberAsync(string guildId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<HttpResult<Member>>> GetGuildMembersAsync(string guildId, GuildMembersPager pager)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<MessageReactionUsers>> GetMessageReactionUsersAsync(string channelId, string messageId, Emoji emoji, MessageReactionPager pager)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<MessageSetting>> GetMessageSettingAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<APIPermissions>> GetPermissionAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<PinsMessage>> GetPinsAsync(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<GuildRoles>> GetRolesAsync(string guildId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Schedule>> GetScheduleAsync(string channelId, string scheduleId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> GuildMuteAsync(string guildId, UpdateGuildMute mute)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<List<Schedule>>> ListSchedulesAsync(string channelId, long since)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<List<Member>>> ListVoiceChannelMembersAsync(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<User>> MeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<List<Guild>>> MeGuildsAsync(GuildPager pager)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> MemberAddRoleAsync(string guildId, string roleId, string userId, MemberAddRoleBody value)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> MemberDeleteRoleAsync(string guildId, string roleId, string userId, MemberAddRoleBody value)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> MemberMuteAsync(string guildId, string userId, UpdateGuildMute mute)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Message>> MessageAsync(string channelId, string messageId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<List<Message>>> MessagesAsync(string channelId, MessagesPager pager)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Schedule>> ModifyScheduleAsync(string channelId, string scheduleId, Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<UpdateGuildMuteResponse>> MultiMemberMuteAsync(string guildId, UpdateGuildMute mute)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Channel>> PatchChannelAsync(string guildId, ChannelValueObject channel)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<UpdateResult>> PatchRoleAsync(string guildId, string roleId, Role role)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<AudioControl>> PostAudio(string channelId, AudioControl audioControl)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Channel>> PostChannelAsync(string guildId, ChannelValueObject channel)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Message>> PostDirectMessageAsync(DirectMessage directMessage, MessageToCreate message)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Message>> PostDMSettingGuideAsync(DirectMessage directMessage, string jumpGuildId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Message>> PostMessageAsync(string channelId, MessageToCreate message)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<UpdateResult>> PostRoleAsync(string guildId, Role role)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<Message>> PostSettingGuideAsync(string channelId, IEnumerable<string> atUserId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> PutChannelPermissionsAsync(string channelId, string userId, UpdateChannelPermissions channelPermissions)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> PutChannelRolesPermissionsAsync(string channelId, string roleId, UpdateChannelPermissions channelPermissions)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> PutInteractionAsync(string interactionId, string body)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<APIPermissionDemand>> RequireAPIPermissions(string guildId, APIPermissionDemandToCreate demand)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> RetractDMMessageAsync(string guildId, string messageId, IEnumerable<RetractMessageOption>? options = null)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<EmptyObject>> RetractMessageAsync(string channelId, string messageId, IEnumerable<RetractMessageOption>? options = null)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Version()
            => 1;
    }
}
