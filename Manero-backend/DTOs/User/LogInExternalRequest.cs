using Manero_backend.Interfaces.Users.Models;

namespace Manero_backend.DTOs.User
{
    public class LogInExternalRequest : ILogInExternalRequest
    {
        public string Email { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;

    }
}
