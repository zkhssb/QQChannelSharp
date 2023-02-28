using QQChannelSharp.Dto.Schedules;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 日程相关接口
    /// </summary>
    public interface IScheduleApi
    {
        /// <summary>
        /// 查询某个子频道下，since开始的当天的日程列表。若since为0，默认返回当天的日程列表
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="since"></param> 我不知道是啥 =3=
        /// <returns></returns>
        Task<List<Schedule>> ListSchedulesAsync(string channelId, long since);

        /// <summary>
        /// 获取某个子频道单个日程信息
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="scheduleId">日程ID</param>
        /// <returns></returns>
        Task<Schedule> GetScheduleAsync(string channelId, string scheduleId);

        /// <summary>
        /// 创建日程
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="schedule">日程信息</param>
        /// <returns></returns>
        Task<Schedule> CreateScheduleAsync(string channelId, Schedule schedule);

        /// <summary>
        /// 更改日程
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="scheduleId">日程ID</param>
        /// <param name="schedule">新的日程信息</param>
        /// <returns></returns>

        Task<Schedule> ModifyScheduleAsync(string channelId, string scheduleId, Schedule schedule);

        /// <summary>
        /// 删除日程
        /// </summary>
        /// <param name="channelId">子频道ID</param>
        /// <param name="scheduleId">日程ID</param>
        /// <returns></returns>
        Task DeleteScheduleAsync(string channelId, string scheduleId);
    }
}
