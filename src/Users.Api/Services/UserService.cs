using Users.Api.Domain.Users;
using Users.Api.Models;
using Users.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Users.Api.Services
{
    public class UserService
    {
        private readonly UsersDbContext _context;

        public UserService(UsersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

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
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null) 
                return null;

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is not null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
