using Manero_backend.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Interfaces.Users.Service
{
    public interface IUserService
    {
        public Task<UserResponse> GetAsync(string id);
        public Task<ICollection<UserResponse>> GetAllAsync();
        public Task<IActionResult> DeleteAsync(string id);

        public Task<string> UpdateAsync(UpdateUser updateUser, string id);
    }
}
