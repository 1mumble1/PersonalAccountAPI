using Domain.Entities;
using PersonalAccountAPI.Dto;

namespace Domain.Abstractions.Repositories;
public interface IScheduleRepository
{
    Task<Schedule> CreateByIdGroup(int groupId, Schedule schedule);
    Task<int> UpdateByIdGroup(int groupId, Schedule modifiedSchedule);
    Task<int> DeleteByIdGroupWithDayOfWeek(int groupId, byte DayOfWeek);
    Task<int> DeleteByIdGroup(int groupId);
    Task<List<ScheduleResponse>> GetScheduleByIdGroup(int groupId);
}
