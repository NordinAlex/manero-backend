using Manero_backend.Models.UserEntities;

namespace Manero_backend.DTOs.User
{
    public class SignUpRequest
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public static implicit operator UserEntity(SignUpRequest signupReuqest)
        {
            // denna raderar allt med addresser?????????? i controllern så Createar den (userentity och pw?) är det det?
            return new UserEntity
            {
                Email = signupReuqest.Email,
                Name = signupReuqest.Name,
                PasswordHash = signupReuqest.Password
            };
        }
    }
}
