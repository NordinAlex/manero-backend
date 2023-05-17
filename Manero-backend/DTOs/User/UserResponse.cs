using Manero_backend.Interfaces.Users.Models;

namespace Manero_backend.DTOs.User
{
    public class UserResponse : IUserResponse
    {
        public string Id {  get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? StatusMessage { get; set; }
        public bool Error { get; set; } = false;
    }
}
