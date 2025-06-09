
namespace Users.Api.Domain.Jokes;
public class Joke
{
    public string Id { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string[] Category { get; set; } = Array.Empty<string>();
}