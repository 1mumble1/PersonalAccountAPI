using Domain.Entities;
using Domain.Abstractions.Dto;

namespace Domain.Abstractions.Repositories;
public interface IScheduleRepository
{
    Task<Schedule> CreateByIdGroup(int groupId, ScheduleResponseWithoutId scheduleResponse);
    Task<int> Update(ScheduleResponse scheduleResponse);
    Task<int> DeleteByIdGroupWithDayOfWeek(int groupId, byte DayOfWeek);
    Task<int> DeleteByIdGroup(int groupId);
    Task<List<ScheduleResponse>> GetScheduleByIdGroup(int groupId);
    Task<int> Delete(int scheduleId);
}
