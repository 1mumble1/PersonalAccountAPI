using System.Text.RegularExpressions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PersonalAccountAPI.Dto;
namespace Infrastructure.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly AppDbContext _dbContext;
    public ScheduleRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<ScheduleResponse>> GetScheduleByIdGroup(int groupId)
    {
        var schedules = await _dbContext.Schedules
        .Include(s => s.SchedulesToLessons)
            .ThenInclude(stl => stl.Lesson)
        .Where(s => s.GroupId == groupId)
        .ToListAsync();

        var scheduleResponses = schedules.Select(schedule => new ScheduleResponse
        {
            DayOfWeek = schedule.DayOfWeek,
            Lessons = schedule.SchedulesToLessons.Select(stl => new LessonsDto
            {
                LessonName = stl.Lesson.Name,
                StartTime = stl.StartTime,
                EndTime = stl.EndTime
            }).ToList()
        }).ToList();

        return scheduleResponses;
    }

    public async Task<Schedule> CreateByIdGroup(int groupId, Schedule schedule)
    {
        schedule.SetGroupId(groupId);
        await _dbContext.AddAsync(schedule);
        await _dbContext.SaveChangesAsync();

        return schedule;
    }

    public async Task<int> DeleteByIdGroupWithDayOfWeek(int groupId, byte DayOfWeek)
    {
        int deletedCount = await _dbContext.Schedules
             .Where(s => s.DayOfWeek == DayOfWeek && s.GroupId == groupId)
             .ExecuteDeleteAsync();

        return deletedCount;
    }

    public async Task<int> DeleteByIdGroup(int groupId)
    {
        var rowsDeleted = await _dbContext.Schedules
            .Where(s => s.GroupId == groupId)
            .ExecuteDeleteAsync();

        return rowsDeleted;
    }

    public async Task<int> UpdateByIdGroup(int groupId, Schedule modifiedSchedule)
    {
        var existingSchedule = await _dbContext.Schedules
        .FirstOrDefaultAsync(s => s.Id == modifiedSchedule.Id && s.GroupId == groupId);

        existingSchedule.SetDayOfWeek(modifiedSchedule.DayOfWeek);

        existingSchedule.SetSchedulesToLessons(modifiedSchedule.SchedulesToLessons);

        _dbContext.Schedules.Update(modifiedSchedule);
        await _dbContext.SaveChangesAsync();

        return modifiedSchedule.Id;
    }

    //бля тут такая ебля с private set в сущностях я не ебу как правильно
    //так что если косяк на косяке получился извиняй братан :)
}
