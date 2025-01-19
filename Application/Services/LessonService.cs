using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;
using PersonalAccountAPI.Dto;

namespace Application.Services;

public class LessonService : ILessonService
{
    private readonly ILessonRepository _lessonRepository;

    public LessonService(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<Lesson> CreateLesson(Lesson lesson)
    {
        return await _lessonRepository.Create(lesson);
    }

    public async Task<int> DeleteLesson(int id)
    {
        return await _lessonRepository.Delete(id);
    }

    public async Task<List<LessonsDto>> GetAllLessons()
    {
        return await _lessonRepository.GetAll();
    }

    public async Task<LessonsDto> GetLessonById(int id)
    {
        return await _lessonRepository.GetById(id);
    }

    public async Task<int> UpdateLesson(Lesson modifiedLesson)
    {
        return await _lessonRepository.Update(modifiedLesson);
    }
}
