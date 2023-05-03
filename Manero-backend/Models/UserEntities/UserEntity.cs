

namespace Manero_backend.Models.UserEntities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Location { get; set; } = null!;
        public ICollection<UserAddressEntity> UserAddresses { get; set; } = new HashSet<UserAddressEntity>();
        public ICollection<UserCompanyEntity> UserCompanies { get; set; } = new HashSet<UserCompanyEntity>();

    }
}
