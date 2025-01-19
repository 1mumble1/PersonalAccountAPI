using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;
using Microsoft.Identity.Client;
using PersonalAccountAPI.Dto;

namespace Application.Services;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;

    public ScheduleService(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public async Task<Schedule> CreateScheduleForGroup(int groupId, Schedule schedule)
    {
        return await _scheduleRepository.CreateByIdGroup(groupId, schedule);
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

    public async Task<int> UpdateScheduleByGroupId(int groupId, Schedule modifiedSchedule)
    {
        var existingSchedule = await _scheduleRepository.GetScheduleByIdGroup(groupId);
        
        if (existingSchedule == null)
        {
            throw new Exception($"Schedule for groupId {groupId} not found");
        }

        return await _scheduleRepository.UpdateByIdGroup(groupId, modifiedSchedule);
    }
}
