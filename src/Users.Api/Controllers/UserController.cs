using Microsoft.AspNetCore.Mvc;
using Users.Api.Models;
using Users.Api.Services;
using Users.Api.Domain.Users;
using System.Threading.Tasks;
using System.Linq;
using Users.Api.Exceptions;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController(UserService userService) : ControllerBase
    {
        private readonly UserService _userService = userService;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users.Select(UserResponse.FromDomainModel));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user is null) 
            throw new NotFoundException($"User with ID '{id}' was not found.");
            return Ok(UserDetailResponse.FromDomainModel(user));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.RegisterUser(request);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, UserDetailResponse.FromDomainModel(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.UpdateUser(id, request);
            if (user is null)
                throw new NotFoundException($"User with ID '{id}' was not found.");
            return Ok(UserDetailResponse.FromDomainModel(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userService.GetUserById(id);
            
            if (user is null)
                throw new NotFoundException($"User with ID '{id}' was not found.");

            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
