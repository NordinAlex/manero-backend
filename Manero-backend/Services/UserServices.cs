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
        private readonly TokenService _tokenService;

        public UserServices(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> DeleteAsync(string id) // INTE TESTAD PATRIK
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null!)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded) { return StatusFactory<OkResult>.Create(); }
                else { return StatusFactory<NotFoundResult>.Create(); } 
            }
            return StatusFactory<BadRequestResult>.Create();
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
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id) ?? null!;
        }

        public async Task<string> UpdateAsync(UpdateUser updateUser, string email) // EJ TESTAD
        {
            var entity = await _userManager.FindByEmailAsync(email);

            if (entity != null)
            {
                if(updateUser.FirstName != null) 
                    entity.FirstName = updateUser.FirstName;
                if (updateUser.LastName != null)
                    entity.LastName = updateUser.LastName;
                if (updateUser.PhoneNumber != null)
                    entity.PhoneNumber = updateUser.PhoneNumber;

                await _userManager.UpdateAsync(entity);

                var token = await _tokenService.CreateToken(entity, "User");
                return token;
            }
            return null!;
        }
    }
}
