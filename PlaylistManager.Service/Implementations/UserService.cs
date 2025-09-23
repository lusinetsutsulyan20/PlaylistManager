using Core.Interfaces;
using Core.Models;
using Service.Interfaces;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User?> GetUserByIdAsync(int id) => await _userRepo.GetByIdAsync(id);

        public async Task<User?> GetUserByUsernameAsync(string username) =>
            await _userRepo.GetByUsernameAsync(username);
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepo.GetAllAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepo.AddAsync(user);
            await _userRepo.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _userRepo.Update(user);
            await _userRepo.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user != null)
            {
                _userRepo.Delete(user);
                await _userRepo.SaveChangesAsync();
            }
        }
    }
}
