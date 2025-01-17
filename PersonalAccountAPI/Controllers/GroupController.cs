using Domain.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using PersonalAccountAPI.Dto;

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