using Manero_backend.DTOs.Product;
using Manero_backend.DTOs.User;

namespace Manero_backend.Interfaces.Product.Services
{
    public interface IUserService
    {
        Task<UserResponse> CreateUserAsync(UserRequest userRequest);
    }
}
