using Users.Api.Common.Interfaces.Service;

namespace Users.Api.Infrastructure.Services.Joke;

public class CustomJokeService : IJokeService
{
    public Task<Domain.Jokes.Joke> GetRandomJokeAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string[]> GetCategoryAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Jokes.Joke> GetJokesByCategoryAsync(string category)
    {
        throw new NotImplementedException();
    }
}