using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Users.Api.Domain.Chuck;


namespace Users.Api.Services;

public class ChuckService
{
    private readonly HttpClient _httpClient;

    public ChuckService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<ChuckNorrisJoke?> GetRandomJokeAsync()
        => _httpClient.GetFromJsonAsync<ChuckNorrisJoke>("jokes/random");

    public Task<string[]?> GetCategoriesAsync()
        => _httpClient.GetFromJsonAsync<string[]>("jokes/categories");

    public Task<ChuckNorrisJoke?> GetJokeByCategoryAsync(string category)
        => _httpClient.GetFromJsonAsync<ChuckNorrisJoke>($"jokes/random?category={category}");
}
