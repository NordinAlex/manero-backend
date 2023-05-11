using System.ComponentModel.DataAnnotations;

namespace Manero_backend.Interfaces.Users.Models
{
    public interface ILogInReq
    {
        public string Email { get; set; } 
        public string Password { get; set; } 
    }
}
