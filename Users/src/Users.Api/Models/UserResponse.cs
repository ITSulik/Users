namespace Users.Api.Models;

using Users.Api.Domain.Users;

public sealed record UserResponse(
     Guid Id,
     string FullName
){
public static UserResponse FromDomainModel(User user) => new UserResponse(user.Id, $"{user.FirstName} {user.LastName}");
    
}
