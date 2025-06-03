using Microsoft.AspNetCore.Mvc;
using Users.Api.Models;
using Users.Api.Services;

namespace Users.Api.Controllers;

[ApiController]
[Route("users")]
public class UserController(UserService userService) : ControllerBase
{
    private readonly UserService _userService = userService;

    [HttpGet]
    public IActionResult GetAllUsers() => Ok(_userService.GetAllUsers());

    [HttpGet("{id}")]
    public IActionResult GetUserById(Guid id) =>
        _userService.GetUserById(id) is { } user ? Ok(user) : NotFound();

    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = _userService.RegisterUser(request);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, [FromBody] UpdateUserRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = _userService.UpdateUser(id, request);
        return user is not null ? Ok(user) : NotFound();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        var user = _userService.GetUserById(id);
        if (user is null) return NotFound();

        _userService.DeleteUser(id);
        return NoContent();
    }
}
