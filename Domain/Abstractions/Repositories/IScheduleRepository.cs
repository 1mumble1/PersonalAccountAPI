using Domain.Entities;
using PersonalAccountAPI.Dto;

namespace Domain.Abstractions.Repositories;
public interface IScheduleRepository
{
    Task<Schedule> Create(Schedule schedule);
    Task<int> Update(Schedule modifiedSchedule);
    Task<int> Delete(int id);
    Task<List<ScheduleResponse>> GetByIdGroup(int groupId);
    // GetAll()?????? хз хз надо или нет
}
