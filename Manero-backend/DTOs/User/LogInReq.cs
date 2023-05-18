using Manero_backend.Interfaces.Users.Models;
using System.ComponentModel.DataAnnotations;

namespace Manero_backend.DTOs.User
{
    public class LogInReq : ILogInReq
    {
        //[Required(ErrorMessage = "PLEASE ENTER AN EMAIL")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "EMAIL")]
        public required string Email { get; set; }
        //[Required(ErrorMessage = "PLEASE ENTER A PASSWORD")]
        [DataType(DataType.Password)]
        [Display(Name = "PASSWORD")]
        public string Password { get; set; }

    }
}
