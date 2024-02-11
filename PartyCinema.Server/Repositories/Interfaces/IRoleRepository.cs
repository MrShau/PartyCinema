using PartyCinema.Server.Models;

namespace PartyCinema.Server.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        public Task<Role?> Add(Role role);
        public Task<Role?> Get(string name);
        public Task<Role?> Get(int id);

    }
}
