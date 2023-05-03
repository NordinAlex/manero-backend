using Manero_backend.Models.UserEntities;

namespace Manero_backend.DTOs.User
{
    public class ProfileRequest
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Location { get; set; } = null!;


        public static implicit operator UserEntity(ProfileRequest profileReuqest)
        {
            var names = profileReuqest.Name.Split(',');

            return new UserEntity
            {
                UserName = profileReuqest.Email,
                FirstName = names[0],
                LastName = names[1],
                Email = profileReuqest.Email,
                PhoneNumber = profileReuqest.PhoneNumber,
                Location = profileReuqest.Location
            };
        }
    }
}
