namespace Manero_backend.Interfaces.Users.Models
{
    public interface IUserRequest
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string ConfirmPassword { get; set; } 
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedBy { get; set; }
    }
}
