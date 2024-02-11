using Microsoft.EntityFrameworkCore;
using PartyCinema.Server.Models;
using PartyCinema.Server.Repositories.Interfaces;

namespace PartyCinema.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool IsExist(string login) => _context.Users.FirstOrDefault(u => u.Login == login.ToLower()) != null;

        public async Task<User?> Add(User user)
        {
            User? result = null;
            try
            {
                result = (await _context.Users.AddAsync(user))?.Entity;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            return result;
        }

        public async Task<User?> Get(string login) => await _context.Users.FirstOrDefaultAsync(u => u.Login == login.ToLower());
        public async Task<User?> Get(int id) => await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
}
