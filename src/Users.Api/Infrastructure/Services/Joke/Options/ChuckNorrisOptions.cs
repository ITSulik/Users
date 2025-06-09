namespace Users.Api.Infrastructure.Services.Joke.Options;

public sealed class ChuckNorrisOptions
{
    public const string SectionName = "ChuckNorris";

    public Uri Host { get; init; } = null!;
}