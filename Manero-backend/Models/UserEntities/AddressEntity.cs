using Manero_backend.Interfaces.Product.Models;
using System.Runtime.CompilerServices;

namespace Manero_backend.Models.UserEntities
{
    public class AddressEntity : IAddressEntity
    {
        public AddressEntity()
        {
            this.Users = new HashSet<UserEntity>();
        }

        public int Id { get; set; }
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string? City { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
