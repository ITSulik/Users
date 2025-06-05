
namespace Users.Api.Domain.Chuck;
public class ChuckNorrisJoke
{
    public string Id { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string[] Categories { get; set; } = Array.Empty<string>();
}