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

    public async Task<Schedule> Create(Schedule schedule)
    {
        await _dbContext.AddAsync(schedule);
        await _dbContext.SaveChangesAsync();
        
        return schedule;
    }

    public async Task<int> Delete(int id)
    {
        await _dbContext.Schedules
            .Where(s => s.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }


    public async Task<int> Update(Schedule modifiedSchedule)
    {
        _dbContext.Schedules.Update(modifiedSchedule);
        await _dbContext.SaveChangesAsync();

        return modifiedSchedule.Id;
    }
}
