using Manero_backend.Models.UserEntities;
using Manero_backend.Models;

namespace Manero_backend.Interfaces.Product.Models
{
    public interface IUserEntity
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public ICollection<AddressEntity> Addresses { get; set; }
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
