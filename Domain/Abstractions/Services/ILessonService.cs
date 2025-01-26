using Domain.Entities;
using Domain.Abstractions.Dto;

namespace Domain.Abstractions.Services;

public interface ILessonService
{
    Task<LessonsDto> GetLessonById(int id);
    Task<List<LessonsDto>> GetAllLessons();
    Task<Lesson> CreateLesson(Lesson lesson);
    Task<int> UpdateLesson(Lesson modifiedLesson);
    Task<int> DeleteLesson(int id);
}
