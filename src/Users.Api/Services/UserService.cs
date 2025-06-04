using Users.Api.Domain.Users;
using Users.Api.Models;
using Users.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Users.Api.Services;

public class UserService(UsersDbContext context)
{
    // private static readonly List<User> _users = new();

    // public IEnumerable<User> GetAllUsers() => _users;

    // public User? GetUserById(Guid id) =>
    //     _users.FirstOrDefault(u => u.Id == id);

    // public User RegisterUser(RegisterUserRequest request)
    // {
    //     var user = new User
    //     {
    //         Id = Guid.NewGuid(),
    //         FirstName = request.FirstName,
    //         LastName = request.LastName,
    //         Email = request.Email
    //     };

    //     _users.Add(user);
    //     return user;
    // }

    // public User? UpdateUser(Guid id, UpdateUserRequest request)
    // {
    //     var user = _users.FirstOrDefault(u => u.Id == id);
    //     if (user is null) return null;

    //     user.FirstName = request.FirstName;
    //     user.LastName = request.LastName;
    //     user.Email = request.Email;

    //     return user;
    // }

    // public void DeleteUser(Guid id)
    // {
    //     var user = _users.FirstOrDefault(u => u.Id == id);
    //     if (user is not null)
    //     {
    //         _users.Remove(user);
    //     }
    // }
    public readonly UsersDbContext _context = context;
    public async Task<IEnumerable<User>> GetAllUsers() => await _context.Users.ToListAsync();
    public User? GetUserById(Guid id) =>
        _context.Users.FirstOrDefault(u => u.Id == id);
    public async Task<User> RegisterUser(RegisterUserRequest request)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task<User?> UpdateUser(Guid id, UpdateUserRequest request)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user is null) return null;

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;

        await _context.SaveChangesAsync();
        return user;
    }
    public async Task DeleteUser(Guid id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user is not null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

}
