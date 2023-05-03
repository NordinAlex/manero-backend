using Manero_backend.DTOs.Review;
using Manero_backend.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace Manero_backend.Models.UserEntities
{
    public class UserEntity : IdentityUser
    {
        // Bild 09 i adobe xd

        [ProtectedPersonalData]
        public string? Name { get; set; }

        [ProtectedPersonalData]
        public string? Password { get; set; }

        [ProtectedPersonalData]
        public string? ConfirmPassword { get; set; }    

        public ICollection<UserAddressEntity> UserAddresses { get; set; } = new HashSet<UserAddressEntity>();

        public ICollection<UserCompanyEntity> UserCompanies { get; set; } = new HashSet<UserCompanyEntity>();

        public static implicit operator SignUpResponse(UserEntity entity)
        {
            var res = new SignUpResponse
            {
                Name = entity.Name!,
                Password = entity.Password!
            };

            return res;
        }
    }
}
