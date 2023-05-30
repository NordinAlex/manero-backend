using Manero_backend.Interfaces.Users.Models;

namespace Manero_backend.DTOs.User
{
    public class UserResponse : IUserResponse
    {
        public string? Token { get; set; }
        public string? StatusMessage { get; set; }
        public bool Error { get; set; } = false;
        public UserRequest? Request { get; set; }
    }
}
