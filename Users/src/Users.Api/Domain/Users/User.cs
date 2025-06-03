namespace Users.Api.Domain.Users;

public record User
{
    public Guid Id;
    public string FirstName  = null!;
    public string LastName  = null!;
    public string Email  = null!;
}