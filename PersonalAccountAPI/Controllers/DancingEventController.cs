using Domain.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Domain.Abstractions.Dto;
using System.Threading.Tasks;

namespace PersonalAccountAPI.Controllers;

[ApiController]
[Route("dancingEvent")]
public class DancingEventController : ControllerBase
{
    private readonly IDancingEventService _dancingEventService;

    public DancingEventController(IDancingEventService dancingEventService)
    {
        _dancingEventService = dancingEventService;
    }

    [HttpGet("{groupId:int}")]
    public async Task<ActionResult<List<DancingEventDto>>> GetEvent([FromRoute] int groupId)
    {
        var schedule = await _dancingEventService.GetDancingEventsByGroupId(groupId);
        return Ok(schedule);
    }

    [HttpPost("{groupId:int}")]
    public async Task<ActionResult<DancingEvent>> CreateDancinigEvent([FromRoute] int groupId, [FromBody] DancingEventDtoWithoutId response)
    {
        var createSchedule = await _dancingEventService.CreateDancingEventForGroup(groupId, response);

        return Ok(createSchedule);
    }

    [HttpPut("")]
    public async Task<ActionResult<DancingEventDto>> UpdateDancingEvent([FromBody] DancingEventDto modifiedEvent)
    {
        var newSchedule = await _dancingEventService.UpdateDancingEvent(modifiedEvent);
        return Ok(newSchedule);
    }
        
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteDancingEvent([FromRoute] int id)
    {
        await _dancingEventService.DeleteDancingEvent(id);
        return Ok(id);
    }
}
