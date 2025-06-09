using Users.Api.Domain.Jokes;

namespace Users.Api.Common.Interfaces.Service;


public interface IJokeService
{

    Task<Joke> GetRandomJokeAsync();
    Task<string[]> GetCategoryAsync();
    Task<Joke> GetJokesByCategoryAsync(string category);
}