using Manero_backend.DTOs.User;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Users.Models;
using Manero_backend.Models.OrderEntities;
using Microsoft.AspNetCore.Identity;

namespace Manero_backend.Models.UserEntities
{
    public class UserEntity : IdentityUser, IUserEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
