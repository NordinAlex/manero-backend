using Microsoft.AspNetCore.Identity;

namespace Manero_backend.Models.UserEntities
{
    public class UserEntity : IdentityUser
    {
        [ProtectedPersonalData]
        public string? Name { get; set; }

        [ProtectedPersonalData]
        public string? Password { get; set; }

        [ProtectedPersonalData]
        public string? ConfirmPassword { get; set; }    

        public ICollection<UserAddressEntity> UserAddresses { get; set; } = new HashSet<UserAddressEntity>();

        public ICollection<UserCompanyEntity> UserCompanies { get; set; } = new HashSet<UserCompanyEntity>();
    }
}
