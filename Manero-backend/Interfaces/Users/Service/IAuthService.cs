using Manero_backend.DTOs.Product;
using Manero_backend.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Interfaces.Users.Service
{
    public interface IAuthService
    {
        Task<string> CreateUserAsync(UserRequest userRequest);
        Task<string> CreateSocialAsync(UserRequest userRequest);
        Task<bool> CheckEmailAsync(string email);
        Task<string> LogInAsync(LogInReq logInReq);
    }
}
