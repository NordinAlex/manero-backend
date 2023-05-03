using Manero_backend.Models.UserEntities;
using System.ComponentModel.DataAnnotations;

namespace Manero_backend.DTOs.User
{
    public class SignUpRequest
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;

    }
}
