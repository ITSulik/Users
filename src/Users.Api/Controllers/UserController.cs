using Microsoft.AspNetCore.Mvc;
using Users.Api.Models;
using Users.Api.Services;
using Users.Api.Domain.Users;
using System.Threading.Tasks;


namespace Users.Api.Controllers;

[ApiController]
[Route("users")]
public class UserController(UserService userService) : ControllerBase
{
    //     private readonly UserService _userService = userService;


    //     [HttpGet]
    //     public IActionResult GetAllUsers() =>
    //     Ok(_userService.GetAllUsers().Select(UserResponse.FromDomainModel));

    //     [HttpGet("{id}")]
    //     public IActionResult GetUserById(Guid id) =>
    //     _userService.GetUserById(id) is { } user
    //         ? Ok(UserDetailResponse.FromDomainModel(user))
    //         : NotFound();

    //     [HttpPost]
    //     public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    // {
    //     if (!ModelState.IsValid)
    //         return BadRequest(ModelState);

    //     var user = _userService.RegisterUser(request);
    //     return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, UserDetailResponse.FromDomainModel(user));
    // }

    //     [HttpPut("{id}")]
    //     public IActionResult UpdateUser(Guid id, [FromBody] UpdateUserRequest request)
    // {
    //     if (!ModelState.IsValid)
    //         return BadRequest(ModelState);

    //     var user = _userService.UpdateUser(id, request);
    //     return user is not null ? Ok(UserDetailResponse.FromDomainModel(user)) : NotFound();
    // }
    //     [HttpDelete("{id}")]
    //     public IActionResult DeleteUser(Guid id)
    // {
    //     var user = _userService.GetUserById(id);
    //     if (user is null) return NotFound();

    //     _userService.DeleteUser(id);
    //     return NoContent();
    // }
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsers();
        return Ok(users.Select(UserResponse.FromDomainModel));
    }
    [HttpGet("{id}")]
    public IActionResult GetUserById(Guid id)
    {
        var user = userService.GetUserById(id);
        return user is not null ? Ok(UserDetailResponse.FromDomainModel(user)) : NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await userService.RegisterUser(request);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, UserDetailResponse.FromDomainModel(user));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await userService.UpdateUser(id, request);
        return user is not null ? Ok(UserDetailResponse.FromDomainModel(user)) : NotFound();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var user = userService.GetUserById(id);
        if (user is null) return NotFound();

        await userService.DeleteUser(id);
        return NoContent();
    }
}
