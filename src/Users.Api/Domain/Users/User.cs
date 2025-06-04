namespace Users.Api.Domain.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Users")]
public class User
{
    public Guid Id;
    public string FirstName = null!;
    public string LastName = null!;
    public string Email = null!;
}