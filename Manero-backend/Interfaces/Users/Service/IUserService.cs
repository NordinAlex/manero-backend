using Manero_backend.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Interfaces.Users.Service
{
    public interface IUserService
    {
        //Julius o Oscar ändrade GetAsync till email från id
        public Task<UserResponse> GetAsync(string email);
        public Task<ICollection<UserResponse>> GetAllAsync();

        //På deletasync ändrade Oscar, julius från Id till email
        public Task<IActionResult> DeleteAsync(string email);

        public Task<string> UpdateAsync(UpdateUser updateUser, string email);
    }
}
