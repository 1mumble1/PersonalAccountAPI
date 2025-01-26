using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Abstractions.Dto;

namespace Infrastructure.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly AppDbContext _dbContext;
    public LessonRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Lesson> Create(Lesson lesson)
    {
        await _dbContext.Lessons.AddAsync(lesson);
        await _dbContext.SaveChangesAsync();

        return lesson;
    }

    public async Task<int> Delete(int id)
    {
        await _dbContext.Lessons
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<List<LessonsDto>> GetAll()
    {
        var lessons = await _dbContext.Lessons
            .AsNoTracking()
            //.Include(l => l.SchedulesToLessons)
            /*.SelectMany(l => l.SchedulesToLessons.Select(sl => new LessonsDto
            {
                LessonName = l.Name,
                StartTime = sl.StartTime,
                EndTime = sl.EndTime,
            }))*/
            .Select(l => new LessonsDto
            {
                LessonName = l.Name,
            })
            .ToListAsync();

        return lessons;
    }

    public async Task<LessonsDto> GetById(int id)
    {
        var lesson = await _dbContext.Lessons
            .AsNoTracking()
            //.Include(l => l.SchedulesToLessons)
            .Where(l => l.Id == id)
            .Select(l => new LessonsDto
            {
                LessonName = l.Name,
                //StartTime = l.SchedulesToLessons.FirstOrDefault()!.StartTime,
                //EndTime = l.SchedulesToLessons.FirstOrDefault()!.EndTime,
            })
            .FirstOrDefaultAsync();
        
        return lesson;
    }

    public async Task<int> Update(Lesson modifiedLesson)
    {
        _dbContext.Lessons.Update(modifiedLesson);
        await _dbContext.SaveChangesAsync();

        return modifiedLesson.Id;
    }
}
