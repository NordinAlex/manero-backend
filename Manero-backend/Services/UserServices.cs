using Manero_backend.DTOs.User;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Users.Repositories;
using Manero_backend.Interfaces.Users.Service;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> DeleteAsync(string id) // INTE TESTAD PATRIK
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded) { return StatusFactory<OkResult>.Create(); }
                else { return StatusFactory<NotFoundResult>.Create(); } // FACTORY?
            }
            return StatusFactory<BadRequestResult>.Create(); //FACTORY?
        }

        public async Task<ICollection<UserResponse>> GetAllAsync() //Patrik
        {
            try
            {
            var list = new List<UserResponse>(); // FACTORIES? 
            var result = await _userManager.Users.ToListAsync();
            foreach (var user in result)
            {
                UserResponse response = user;
                list.Add(response);
            }
            return list;
            } catch (Exception ex) { return null!; }
        }

        public async Task<UserResponse> GetAsync(string id)
        {
            return await _userManager.Users.SingleOrDefaultAsync(x => x.Id == id) ?? null!;
        }
    }
}
