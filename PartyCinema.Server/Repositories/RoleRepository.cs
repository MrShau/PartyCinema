using Microsoft.EntityFrameworkCore;
using PartyCinema.Server.Models;
using PartyCinema.Server.Repositories.Interfaces;

namespace PartyCinema.Server.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Role?> Add(Role role)
        {
            Role? result = null;
            try
            {
                result = (await _context.Roles.AddAsync(role))?.Entity;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            return result;
        }

        public async Task<Role?> Get(string name) => await _context.Roles.FirstOrDefaultAsync(r => r.Name == name.ToUpper());
        public async Task<Role?> Get(int id) => await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);

    }
}
