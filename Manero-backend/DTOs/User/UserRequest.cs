using System.ComponentModel.DataAnnotations;

namespace Manero_backend.DTOs.User
{
    public class UserRequest
    {
        [Required(ErrorMessage = "PLEASE ENTER YOUR FIRST NAME")]
        [Display(Name = "FIRST NAME")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "PLEASE ENTER YOUR LAST NAME")]
        [Display(Name = "LAST NAME")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "PLEASE ENTER AN EMAIL")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "EMAIL")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "PLEASE ENTER A PASSWORD")]
        [DataType(DataType.Password)]
        [Display(Name = "PASSWORD")]

        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "PLEASE CONFIRM PASSWORD")]
        [Compare(nameof(Password))]
        [Display(Name = "CONFIRM PASSWORD")]
        public string ConfirmPassword { get; set; } = null!;
        [Display(Name = "PHONE NUMBER")]
        public string? PhoneNumber { get; set; }

        public string? ImageUrl { get; set; }

        public string? Issuer { get; set; }

    }
}
