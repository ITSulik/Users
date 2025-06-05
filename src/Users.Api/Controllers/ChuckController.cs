using Microsoft.AspNetCore.Mvc;
using Users.Api.Services;
using Users.Api.Domain.Chuck;

namespace Users.Api.Controllers
{[ApiController]
[Route("jokes")]
public class ChuckController(ChuckService chuckService) : ControllerBase
{
    [HttpGet("random")]
    public async Task<IActionResult> GetRandomJoke()
    {
        var joke = await chuckService.GetRandomJokeAsync();
        return joke is not null 
            ? Ok(joke) 
            : NotFound("No joke found");
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await chuckService.GetCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("random/{category}")]
    public async Task<IActionResult> GetJokeByCategory(string category)
    {
        var joke = await chuckService.GetJokeByCategoryAsync(category);
        return  joke is not null 
            ? Ok(joke) 
            : NotFound("No joke found");
    }
}
}