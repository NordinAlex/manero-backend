using Manero_backend.Factories;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.DTOs.User
{
    public class SignUpRequest
    {
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;

        public static implicit operator UserEntity(SignUpRequest signupReuqest)
        {
            var userEntity = UserEntityFactory.Create();

            userEntity.Name = signupReuqest.Name;
            userEntity.Password = signupReuqest.Password;
            userEntity.ConfirmPassword = signupReuqest.ConfirmPassword;

            return signupReuqest;
        }
    }
}
