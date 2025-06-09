using System.Text.Json.Serialization;

namespace Users.Api.Infrastructure.Services.Joke.Models;

public class JokeResponse
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = null!;

    [JsonPropertyName("value")]
    public string Text { get; init; } = null!;
    [JsonPropertyName("categories")]
    public string[] Category { get; init; } = null!;

    public Domain.Jokes.Joke ToDomainModel() => 
        new()
        {
            Id = Id,
            Text = Text,
            Category = Category ?? Array.Empty<string>()
        };
}