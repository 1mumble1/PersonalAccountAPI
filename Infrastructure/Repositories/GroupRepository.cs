using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Abstractions.Dto;

namespace Infrastructure.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _dbContext;

    public GroupRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GroupResponse> GetById(int id)
    {
        var group = await _dbContext.Groups
            .Include(g => g.Users)
            .Where(g => g.Id == id)
            .Select(g => new GroupResponse
            {
                Name = g.Name,
                Users = g.Users.Select(u => new UserResponse
                {
                    Name = u.Name,
                    Surname = u.Surname,
                }).ToList()
            })
        .FirstOrDefaultAsync();

        return group;
    }

    public async Task<GroupWithSchedulesResponse> GetByIdWithSchedules(int id)
    {
        var group = await _dbContext.Groups
            .Include(g => g.Schedules)
                .ThenInclude(s => s.SchedulesToLessons)
                    .ThenInclude(sl => sl.Lesson)
            .AsNoTracking()
            .Where(g => g.Id == id)
            .Select(g => new GroupWithSchedulesResponse
            {
                Name = g.Name,
                Schedules = g.Schedules.Select(s => new ScheduleResponse
                {
                    DayOfWeek = s.DayOfWeek,
                    Lessons = s.SchedulesToLessons.Select(sl => new LessonsDto
                    {
                        LessonName = sl.Lesson.Name,
                        StartTime = sl.StartTime,
                        EndTime = sl.EndTime
                    }).ToList()
                }).ToList()
            })
        .FirstOrDefaultAsync();

        return group;
    }

    public async Task<List<Group>> GetAll()
    {
        var groups = await _dbContext.Groups
            .AsNoTracking()
            /*.Include(g => g.Users)*/
            .ToListAsync();

        return groups;
    }

    public async Task<List<GroupWithSchedulesResponse>> GetAllWithSchedules()
    {
        var groups = await _dbContext.Groups
            .Include(g => g.Schedules)
                .ThenInclude(s => s.SchedulesToLessons)
                    .ThenInclude(sl => sl.Lesson)
            .AsNoTracking()
            .Select(g => new GroupWithSchedulesResponse
            {
                Id = g.Id,
                Name = g.Name,
                Schedules = g.Schedules.Select(s => new ScheduleResponse
                {
                    Id= s.Id,
                    DayOfWeek = s.DayOfWeek,
                    Lessons = s.SchedulesToLessons.Select(sl => new LessonsDto
                    {
                        Id = sl.Id,
                        LessonName = sl.Lesson.Name,
                        StartTime = sl.StartTime,
                        EndTime = sl.EndTime
                    }).ToList()
                }).ToList()
            })
            .ToListAsync();

        return groups;
    }

    //ПОЛУЧИТЬ ГРУППУ С ИВЕНТОМ ПО id И ALL

    public async Task<Group> Create(Group group)
    {
        await _dbContext.Groups.AddAsync(group);
        await _dbContext.SaveChangesAsync();

        return group;
    }

    public async Task<int> Update(Group modifiedGroup)
    {
        _dbContext.Groups.Update(modifiedGroup);
        await _dbContext.SaveChangesAsync();

        return modifiedGroup.Id;
    }

    public async Task<int> Delete(int id)
    {
        await _dbContext.Groups
            .Where(g => g.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}
