using PartyCinema.Server.Models;

namespace PartyCinema.Server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public bool IsExist(string login);
        public Task<User?> Add(User user);
        public Task<User?> Get(string login);
        public Task<User?> Get(int id);
    }
}
