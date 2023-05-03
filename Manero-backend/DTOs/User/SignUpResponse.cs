using System.ComponentModel.DataAnnotations;

namespace Manero_backend.DTOs.User
{
    public class SignUpResponse
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
 