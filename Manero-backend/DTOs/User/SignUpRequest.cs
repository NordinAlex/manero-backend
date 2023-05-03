using Manero_backend.Models.UserEntities;
using System.ComponentModel.DataAnnotations;

namespace Manero_backend.DTOs.User
{
    public class SignUpRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string CompanyName { get; set; } = null!;


        public static implicit operator UserEntity(SignUpRequest signupReuqest)
        {
            
            return new UserEntity
            {
                FirstName = signupReuqest.FirstName,
                LastName = signupReuqest.LastName,
                Email = signupReuqest.Email

            };
        }
    }
}
