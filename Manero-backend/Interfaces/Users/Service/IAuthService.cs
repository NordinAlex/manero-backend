using Manero_backend.DTOs.Product;
using Manero_backend.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Interfaces.Users.Service
{
    public interface IAuthService
    {
        Task<UserResponse> CreateUserAsync(UserRequest userRequest);
        Task<UserResponse> CreateSocialAsync(UserRequest userRequest);
        Task<bool> CheckEmailAsync(string email);
        Task<UserResponse> LogInAsync(LogInReq logInReq);
        Task<UserResponse> LogInExternalAsync(LogInExternalRequest request);
    }
}
