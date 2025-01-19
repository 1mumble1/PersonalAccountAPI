using Domain.Entities;
using PersonalAccountAPI.Dto;

namespace Domain.Abstractions.Repositories;

public interface ILessonRepository
{
    Task<LessonsDto> GetById(int id);
    Task<List<LessonsDto>> GetAll();
    Task<Lesson> Create(Lesson lesson);
    Task<int> Update(Lesson modifiedLesson);
    Task<int> Delete(int id);
}
