namespace Users.Api.Models;
public class UpdateUserRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; }   = null!;
}