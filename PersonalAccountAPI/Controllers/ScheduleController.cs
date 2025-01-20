using Azure.Core;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using PersonalAccountAPI.Dto;

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
    public async Task<ActionResult<List<ScheduleResponse>>> GetShedule([FromRoute] int groupId)
    {
        var schedule = await _scheduleService.GetScheduleByIdGroup(groupId);
        return Ok(schedule);
    }

    [HttpPost("{groupId:int}")]
    public async Task<ActionResult<ScheduleResponse>> CreateSchedule([FromRoute] int groupId, [FromBody] ScheduleResponse response)
    {
        var schedule = new Schedule(response.DayOfWeek);
        var createSchedule = await _scheduleService.CreateScheduleForGroup(groupId, schedule);

        return Ok(createSchedule);
    }

    [HttpPut("{groupId:int}")]
    public async Task<ActionResult<ScheduleResponse>> UpdateSchedule([FromRoute] int groupId, [FromBody] Schedule modifiedSchedule)
    {
        var newSchedule = await _scheduleService.UpdateScheduleByGroupId(groupId, modifiedSchedule);
        return Ok(newSchedule);
    }

    [HttpDelete("{groupId:int}/{dayOfWeek:int}")]
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
    }

}
