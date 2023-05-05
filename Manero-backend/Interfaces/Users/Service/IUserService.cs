using Manero_backend.DTOs.User;

namespace Manero_backend.Interfaces.Users.Service
{
    public interface IUserService
    {
        public Task<UserResponse> GetAsync(string id);
    }
}
