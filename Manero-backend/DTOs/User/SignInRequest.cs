using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Manero_backend.DTOs.User
{
    public class SignInRequest
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
        public string RememberMe { get; set; } = null!;
        public string ForgotPassword { get; set; } = null!;
        
      
    }
}
