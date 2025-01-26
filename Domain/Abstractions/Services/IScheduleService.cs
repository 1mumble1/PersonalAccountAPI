using Domain.Entities;
using Domain.Abstractions.Dto;
using System.Threading.Tasks;

namespace Domain.Abstractions.Services;

public interface IScheduleService
{
    Task<Schedule> CreateScheduleForGroup(int groupId, ScheduleResponseWithoutId scheduleResponse);
    Task<int> UpdateSchedule(ScheduleResponse modifiedSchedule);
    Task<int> DeleteScheduleByGroupIdWithDayOfWeek(int groupId, byte DayOfWeek);
    Task<int> DeleteScheduleByGroupId(int groupId);
    Task<List<ScheduleResponse>> GetScheduleByIdGroup(int groupId);
    Task<int> DeleteSchedule(int scheduleId);
}
