using Domain.Abstractions.Dto;
using Domain.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PersonalAccountAPI.Controllers;

[ApiController]
[Route("Lesson")]
public class LessonController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet("")]
    public async Task<ActionResult<List<LessonsDto>>> GetLessons()
    {
        var lessons = await _lessonService.GetAllLessons();

        return Ok(lessons);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<LessonsDto>>> GetLessonById([FromRoute] int id)
    {
        var lesson = await _lessonService.GetLessonById(id);

        return Ok(lesson);
    }

    [HttpPost("")]
    public async Task<ActionResult<LessonResponse>> CreateLesson([FromBody] LessonResponse response)
    {
        var newLesson = new Lesson(response.Name);
        await _lessonService.CreateLesson(newLesson);

        return Ok(newLesson);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<LessonResponse>> UpdateLesson([FromRoute] int id, [FromBody] LessonResponse modifiedLesson)
    {
        var lesson = new Lesson(id, modifiedLesson.Name);
        await _lessonService.UpdateLesson(lesson);

        return Ok(lesson);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteLesson([FromRoute] int id)
    {
        await _lessonService.DeleteLesson(id);

        return Ok(id);
    }
}
