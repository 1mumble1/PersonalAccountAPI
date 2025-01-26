using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;
using Domain.Abstractions.Dto;

namespace Application.Services;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;

    public ScheduleService(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public async Task<Schedule> CreateScheduleForGroup(int groupId, ScheduleResponseWithoutId scheduleResponse)
    {
        return await _scheduleRepository.CreateByIdGroup(groupId, scheduleResponse);
    }

    public async Task<int> DeleteScheduleByGroupId(int groupId)
    {
        var schedules = await _scheduleRepository.GetScheduleByIdGroup(groupId);
        if (schedules == null)
        {
            throw new Exception("Schedules for this group not found");
        }

        return await _scheduleRepository.DeleteByIdGroup(groupId);
    }

    public async Task<int> DeleteScheduleByGroupIdWithDayOfWeek(int groupId, byte DayOfWeek)
    {
        var schedule = await _scheduleRepository.GetScheduleByIdGroup(groupId);

        if (schedule == null || !schedule.Any(s => s.DayOfWeek == DayOfWeek))
        {
            throw new Exception("Schedule for this day not found");
        }

        return await _scheduleRepository.DeleteByIdGroupWithDayOfWeek(groupId, DayOfWeek);

    }

    public async Task<List<ScheduleResponse>> GetScheduleByIdGroup(int groupId)
    {
        return await _scheduleRepository.GetScheduleByIdGroup(groupId);
    }

    public async Task<int> UpdateSchedule(ScheduleResponse modifiedSchedule)
    {
        return await _scheduleRepository.Update(modifiedSchedule);
    }
    public async Task<int> DeleteSchedule(int scheduleId)
    {
        return await _scheduleRepository.Delete(scheduleId);
    }
}
