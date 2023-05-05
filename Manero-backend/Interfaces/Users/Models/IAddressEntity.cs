using Manero_backend.Models.UserEntities;

namespace Manero_backend.Interfaces.Users.Models
{
    public interface IAddressEntity
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string? City { get; set; }

        public ICollection<UserEntity> Users { get; set; }
    }
}
