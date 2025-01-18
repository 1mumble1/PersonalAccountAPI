using Domain.Entities;
using PersonalAccountAPI.Dto;

namespace Domain.Abstractions.Services;

public interface IScheduleService
{
    Task<Schedule> CreateScheduleForGroup(int groupId, Schedule schedule);
    Task<int> UpdateScheduleByGroupId(int groupId, Schedule modifiedSchedule);
    Task<int> DeleteScheduleByGroupIdWithDayOfWeek(int groupId, byte DayOfWeek);
    Task<int> DeleteScheduleByGroupId(int groupId);
    Task<List<ScheduleResponse>> GetScheduleByIdGroup(int groupId);
}
