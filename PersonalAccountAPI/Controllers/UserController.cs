using Domain.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using PersonalAccountAPI.Dto;

namespace PersonalAccountAPI.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    //TODO  http-responses ?
    [HttpGet("")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUserById([FromRoute] int id)
    {
        var user = await _userService.GetUserById(id);
        return Ok(user);
    }

    [HttpPost("")]
    public async Task<ActionResult<UserResponse>> CreateUser([FromBody] UserResponse response)
    {
        var user = new User(response.Name, response.Surname, response.UserName, response.Password, response.GroupId, response.Photo);
        await _userService.CreateUser(user);
        return Ok(user);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<UserResponse>> UpdateUser([FromRoute] int id, [FromBody] UserResponse response)
    {
        var user = new User(id, response.Name, response.Surname, response.UserName, response.Password, response.GroupId, response.Photo);
        await _userService.UpdateUser(user);
        return Ok(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteUser([FromRoute] int id)
    {
        await _userService.DeleteUser(id);
        return Ok(id);
    }
}
