using System;  
using Users.Api.Domain.Users;
public sealed record UserDetailResponse
(
    Guid Id,
    string FullName,
    string Email
)
{
    public static UserDetailResponse FromDomainModel(User user) => new(user.Id, $"{user.FirstName} {user.LastName}", user.Email);
}