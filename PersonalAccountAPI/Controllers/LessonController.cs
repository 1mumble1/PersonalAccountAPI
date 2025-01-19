using Domain.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PersonalAccountAPI.Dto;

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
    public async Task<ActionResult<LessonsDto>> CreateLesson([FromBody] LessonsDto response)
    {
        var newLesson = new Lesson(response.LessonName);
        await _lessonService.CreateLesson(newLesson);

        return Ok(newLesson);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<LessonsDto>> UpdateLesson([FromRoute] int id, [FromBody] Lesson modifiedLesson)
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
