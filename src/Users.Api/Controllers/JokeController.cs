using Microsoft.AspNetCore.Mvc;
using Users.Api.Models;
using Users.Api.Common.Interfaces.Service;

namespace Users.Api.Controllers
{[ApiController]
[Route("jokes")]
public class ChuckController(IJokeService service) : ControllerBase
{
    [HttpGet("random")]
    public async Task<IActionResult> GetRandomJoke()
    {
        var joke = await service.GetRandomJokeAsync();
        return Ok(JokeResponse.FromDomainModel(joke));
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await service.GetCategoryAsync();
        return Ok(categories);
    }

    [HttpGet("random/{category}")]
    public async Task<IActionResult> GetJokeByCategory(string category)
    {
        var joke = await service.GetJokesByCategoryAsync(category);
        return Ok(JokeResponse.FromDomainModel(joke));
    }
}
}