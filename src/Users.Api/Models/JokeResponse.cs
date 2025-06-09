using Users.Api.Domain.Jokes;

namespace Users.Api.Models;

public sealed record JokeResponse(string Id, string Text, string[] Category)
{
    public static JokeResponse FromDomainModel(Joke joke) =>
        new(joke.Id, joke.Text, joke.Category);
}