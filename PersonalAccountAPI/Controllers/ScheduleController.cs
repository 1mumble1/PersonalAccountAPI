using Domain.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Domain.Abstractions.Dto;
using System.Threading.Tasks;

namespace PersonalAccountAPI.Controllers;

[ApiController]
[Route("schedule")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleService _scheduleService;

    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet("{groupId:int}")]
    public async Task<ActionResult<List<ScheduleResponse>>> GetSchedule([FromRoute] int groupId)
    {
        var schedule = await _scheduleService.GetScheduleByIdGroup(groupId);
        return Ok(schedule);
    }

    [HttpPost("{groupId:int}")]
    public async Task<ActionResult<Schedule>> CreateSchedule([FromRoute] int groupId, [FromBody] ScheduleResponseWithoutId response)
    {
        var createSchedule = await _scheduleService.CreateScheduleForGroup(groupId, response);

        return Ok(createSchedule);
    }

    [HttpPut("")]
    public async Task<ActionResult<ScheduleResponse>> UpdateSchedule([FromBody] ScheduleResponse modifiedSchedule)
    {
        var newSchedule = await _scheduleService.UpdateSchedule(modifiedSchedule);
        return Ok(newSchedule);
    }

/*    [HttpDelete("{groupId:int}/{dayOfWeek:int}")]
    public async Task<ActionResult> DeleteScheduleByDay([FromRoute] int groupId, [FromRoute] byte DayOfWeek)
    {
        await _scheduleService.DeleteScheduleByGroupIdWithDayOfWeek(groupId, DayOfWeek);
        return Ok(groupId);
    }

    [HttpDelete("{groupId:int}")]
    public async Task<ActionResult> DeleteSchedule([FromRoute] int groupId)
    {
        await _scheduleService.DeleteScheduleByGroupId(groupId);
        return Ok(groupId);
    }*/

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteSchedule([FromRoute] int id)
    {
        await _scheduleService.DeleteSchedule(id);
        return Ok(id);
    }
}
