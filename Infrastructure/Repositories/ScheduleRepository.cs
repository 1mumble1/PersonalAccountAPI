using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Abstractions.Dto;
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
            Id = schedule.Id,
            DayOfWeek = schedule.DayOfWeek,
            Lessons = schedule.SchedulesToLessons.Select(stl => new LessonsDto
            {
                Id = stl.Id,
                LessonName = stl.Lesson.Name,
                StartTime = stl.StartTime,
                EndTime = stl.EndTime
            }).ToList()
        }).ToList();

        return scheduleResponses;
    }

    public async Task<Schedule> CreateByIdGroup(int groupId, ScheduleResponseWithoutId scheduleResponse)
    {
/*        var schedule = new Schedule(scheduleResponse.DayOfWeek);
        schedule.SetGroupId(groupId);
        foreach (LessonsDto lessonDto in scheduleResponse.Lessons)
        {
            var lesson = _dbContext.Lessons.FirstOrDefaultAsync(l => l.Name == lessonDto.LessonName);
            if (lesson == null)
            {
                await _dbContext.Lessons.AddAsync(new Lesson(lessonDto.LessonName));
                lesson = _dbContext.Lessons.FirstOrDefaultAsync(l => l.Name == lessonDto.LessonName);
            }

            var scheduleToLesson = new ScheduleToLesson(lessonDto.StartTime, lessonDto.EndTime);
            scheduleToLesson.SetLessonId(groupId);
            scheduleToLesson.SetScheduleId(schedule.Id);
            await _dbContext.SchedulesToLessons.AddAsync(scheduleToLesson);
        }

        await _dbContext.AddAsync(schedule);
        await _dbContext.SaveChangesAsync();

        return schedule;*/
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            // Создаем и сохраняем Schedule первым
            var schedule = new Schedule(scheduleResponse.DayOfWeek);
            schedule.SetGroupId(groupId);
            await _dbContext.Schedules.AddAsync(schedule);
            await _dbContext.SaveChangesAsync(); // Получаем schedule.Id

            // Обрабатываем уроки
            foreach (var lessonDto in scheduleResponse.Lessons)
            {
                // Ищем или создаем Lesson
                var lesson = await _dbContext.Lessons
                    .FirstOrDefaultAsync(l => l.Name == lessonDto.LessonName);

                if (lesson == null)
                {
                    lesson = new Lesson(lessonDto.LessonName);
                    await _dbContext.Lessons.AddAsync(lesson);
                    await _dbContext.SaveChangesAsync(); // Сохраняем новый Lesson
                }

                // Создаем связь ScheduleToLesson
                var scheduleToLesson = new ScheduleToLesson(lessonDto.StartTime, lessonDto.EndTime);
                scheduleToLesson.SetLessonId(lesson.Id); // Правильный LessonId
                scheduleToLesson.SetScheduleId(schedule.Id); // Существующий ScheduleId

                await _dbContext.SchedulesToLessons.AddAsync(scheduleToLesson);
            }

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return schedule;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
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

    public async Task<int> Delete(int scheduleId)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var schedule = await _dbContext.Schedules
                .Include(s => s.SchedulesToLessons)
                .FirstOrDefaultAsync(s => s.Id == scheduleId);

            if (schedule == null)
                return -1;

            // Удаляем связанные записи
            _dbContext.SchedulesToLessons.RemoveRange(schedule.SchedulesToLessons);
            _dbContext.Schedules.Remove(schedule);

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return schedule.Id;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<int> Update(ScheduleResponse scheduleResponse)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var existingSchedule = await _dbContext.Schedules
                .Include(s => s.SchedulesToLessons)
                .FirstOrDefaultAsync(s => s.Id == scheduleResponse.Id);

            if (existingSchedule == null)
                return -1;

            existingSchedule.SetDayOfWeek(scheduleResponse.DayOfWeek);

            // Удаляем старые связи
            _dbContext.SchedulesToLessons.RemoveRange(existingSchedule.SchedulesToLessons);
            await _dbContext.SaveChangesAsync(); // Сохраняем удаление сразу

            // Обрабатываем новые уроки
            foreach (var lessonDto in scheduleResponse.Lessons)
            {
                // Ищем урок или создаем новый
                var lesson = await _dbContext.Lessons
                    .FirstOrDefaultAsync(l => l.Name == lessonDto.LessonName);

                if (lesson == null)
                {
                    lesson = new Lesson(lessonDto.LessonName);
                    await _dbContext.Lessons.AddAsync(lesson);
                    await _dbContext.SaveChangesAsync(); // Сохраняем новый урок сразу
                }

                // Создаем связь
                var scheduleToLesson = new ScheduleToLesson(
                    lessonDto.StartTime,
                    lessonDto.EndTime);
                scheduleToLesson.SetLessonId(lesson.Id);
                scheduleToLesson.SetScheduleId(existingSchedule.Id);

                await _dbContext.SchedulesToLessons.AddAsync(scheduleToLesson);
            }

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return existingSchedule.Id;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
