using Manero_backend.DTOs.Product;
using Manero_backend.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Interfaces.Users.Service
{
    public interface IRegisterService
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
        Task<UserResponse> GetUserByIdAsync(int id);
        Task<UserResponse> CreateUserAsync(UserRequest userRequest);
        Task<UserResponse> UpdateUserAsync(int id, UserRequest userRequest);
        Task<IActionResult> DeleteUserAsync(int id);
    }
}
