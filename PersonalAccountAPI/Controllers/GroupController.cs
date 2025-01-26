using Domain.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Domain.Abstractions.Dto;

[ApiController]
[Route("group")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("")]
    public async Task<ActionResult<List<Group>>> GetGroups()
    {
        var groups = await _groupService.GetAllGroups();
        return Ok(groups);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Group>> GetGroupById([FromRoute] int id)
    {
        var group = await _groupService.GetGroupById(id);
        return Ok(group);
    }

    [HttpGet("{id:int}/schedule")]
    public async Task<ActionResult<GroupWithSchedulesResponse>> GetGroupByIdWithSchedules([FromRoute] int id)
    {
        var group = await _groupService.GetGroupByIdWithSchedules(id);
        return Ok(group);
    }

    [HttpGet("/schedule")]
    public async Task<ActionResult<List<GroupWithSchedulesResponse>>> GetAllGroupsWithSchedules()
    {
        var groups = await _groupService.GetAllGroupsWithSchedules();
        return Ok(groups);
    }

    [HttpGet("{id:int}/dancingEvents")]
    public async Task<ActionResult<GroupWithEventsResponse>> GetGroupByIdWithEvents([FromRoute] int id)
    {
        var group = await _groupService.GetGroupByIdWithEvents(id);
        return Ok(group);
    }

    [HttpGet("/dancingEvents")]
    public async Task<ActionResult<List<GroupWithEventsResponse>>> GetAllGroupsWithEvents()
    {
        var groups = await _groupService.GetAllGroupsWithEvents();
        return Ok(groups);
    }

    [HttpPost("")]
    public async Task<ActionResult<GroupResponse>> CreateGroup([FromBody] GroupResponse response)
    {
        var group = new Group(response.Name);
        await _groupService.CreateGroup(group);
        return Ok(group);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<GroupResponse>> UpdateGroup([FromRoute] int id, [FromBody] GroupResponse response)
    {
        var group = new Group(id, response.Name);
        await _groupService.UpdateGroup(group);
        return Ok(group);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteGroup([FromRoute] int id)
    {
        await _groupService.DeleteGroup(id);
        return Ok(id);
    }
}