using Core.Interfaces;
using Core.Models;
using PlaylistManager.DB;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<User?> GetByUsernameAsync(string username) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Name == username);
    }
}
