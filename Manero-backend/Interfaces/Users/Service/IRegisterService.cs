using Manero_backend.DTOs.Product;
using Manero_backend.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Interfaces.Users.Service
{
    public interface IRegisterService
    {
        Task<UserResponse> CreateUserAsync(UserRequest userRequest);

        Task<bool> CheckEmailAsync(string email);
    }
}
