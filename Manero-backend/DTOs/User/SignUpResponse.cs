using System.ComponentModel.DataAnnotations;

namespace Manero_backend.DTOs.User
{
    public class SignUpResponse
    {
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
 