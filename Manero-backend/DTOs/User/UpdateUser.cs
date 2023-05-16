using Manero_backend.Interfaces.Users.Models;

namespace Manero_backend.DTOs.User
{
    public class UpdateUser : IUpdateUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
    }
}
