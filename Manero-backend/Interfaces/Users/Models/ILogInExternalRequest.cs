namespace Manero_backend.Interfaces.Users.Models
{
    public interface ILogInExternalRequest
    {
        public string Email { get; set; } 
        public string CreatedBy { get; set; } 
    }
}
