using Manero_backend.DTOs.User;
using Manero_backend.Interfaces.Users.Repositories;
using Manero_backend.Interfaces.Users.Service;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Services
{
    public class UserServices : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;

        public UserServices(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserResponse> GetAsync(string id)
        {
            return await _userManager.Users.SingleOrDefaultAsync(x => x.Id == id) ?? null!;
        }
    }
}
