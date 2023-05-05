using Manero_backend.DTOs.User;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.Interfaces.Users.Repositories
{
    public interface IUserRepository
    {
        public Task<bool> CheckAsync();

        public Task SaveDBAsync();

        public Task<UserResponse> GetAsync(string id);
    }
}
