using Microsoft.EntityFrameworkCore;
using ProgLib.Core.Abstractions;
using ProgLib.Core.Models;
using ProgLib.Persistence.Entitites;

namespace ProgLib.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ProgLibDbContext _context;

        public UsersRepository(ProgLibDbContext context) 
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }
        
        public async Task<User> GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));

            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            if (userEntity == null)
                throw new InvalidOperationException($"User with email {email} not found.");

            return User.Create(userEntity.Id, userEntity.UserName, userEntity.PasswordHash, userEntity.Email);
        }
    }
}
