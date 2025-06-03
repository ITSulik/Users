using Users.Api.Domain.Users;
using Users.Api.Models;

namespace Users.Api.Services;

public class UserService
{
    private static readonly List<User> _users = new();

    public IEnumerable<UserResponse> GetAllUsers() =>
        _users.Select(ToUserResponse);

    public UserDetailResponse? GetUserById(Guid id) =>
        _users.FirstOrDefault(u => u.Id == id) is { } user ? ToUserResponseInfo(user) : null;

    public UserResponse RegisterUser(RegisterUserRequest request)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        _users.Add(user);
        return ToUserResponse(user);
    }

    private static UserResponse ToUserResponse(User user) => new()
    {
        Id = user.Id,
        FullName = $"{user.FirstName} {user.LastName}",  
        
    };
    private static UserDetailResponse ToUserResponseInfo(User user) => new()
    {
        Id = user.Id,
        FullName = $"{user.FirstName} {user.LastName}",  
        Email = user.Email
    };
    public UserResponse? UpdateUser(Guid id, UpdateUserRequest request)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null) return null;

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;

        return ToUserResponse(user);
    }
    public void DeleteUser(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is not null)
        {
            _users.Remove(user);
        }
    }
}
