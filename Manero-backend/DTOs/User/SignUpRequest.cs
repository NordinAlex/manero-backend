using Manero_backend.Models.UserEntities;
using System.ComponentModel.DataAnnotations;

namespace Manero_backend.DTOs.User
{
    public class SignUpRequest
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;


        public static implicit operator UserEntity(SignUpRequest signupReuqest)
        {
            var names = signupReuqest.Name.Split(',');

            return new UserEntity
            {
                UserName = signupReuqest.Email,
                FirstName = names[0],
                LastName = names[1],
                Email = signupReuqest.Email

            };
        }
    }
}
