using Users.Api.Common.Interfaces.Service;
using Users.Api.Infrastructure.Services.Joke.Models;
using System.Net.Http;



namespace Users.Api.Infrastructure.Services.Joke;

public class ChuckNorrisJokeService(HttpClient client) : IJokeService
{
    public async Task<Domain.Jokes.Joke> GetRandomJokeAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "jokes/random");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var joke = await response.Content.ReadFromJsonAsync<JokeResponse>();

        return joke!.ToDomainModel();
    }
    public async Task<string[]> GetCategoryAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "jokes/categories");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<string[]>() ?? Array.Empty<string>();
    }
    public async Task<Domain.Jokes.Joke> GetJokesByCategoryAsync(string category)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"jokes/random?category={category}");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var joke = await response.Content.ReadFromJsonAsync<JokeResponse>();

        return joke!.ToDomainModel();
    }
}