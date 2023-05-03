using Manero_backend.Models.UserEntities;

namespace Manero_backend.DTOs.User
{
    public class UserRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Location { get; set; } = null!;

    }
}
