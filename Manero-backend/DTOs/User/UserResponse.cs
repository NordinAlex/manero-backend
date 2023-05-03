namespace Manero_backend.DTOs.User
{
    public class UserResponse
    {
        public string Id {  get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Location { get; set; } = null!;

    }
}
