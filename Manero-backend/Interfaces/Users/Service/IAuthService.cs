using Manero_backend.DTOs.Product;
using Manero_backend.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Interfaces.Users.Service
{
    public interface IAuthService
    {
        Task<UserResponse> CreateUserAsync(UserRequest userRequest);

        Task<bool> CheckEmailAsync(string email);
        Task<string> LogInAsync(LogInReq logInReq);
    }
}
