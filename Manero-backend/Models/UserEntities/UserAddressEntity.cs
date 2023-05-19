using Manero_backend.Interfaces.Users.Models;

namespace Manero_backend.Models.UserEntities
{
    public class UserAddressEntity : IUserAddressEntity
    {
        public Guid Id { get; set; }
        public int AddressId { get; set; }
        public string Userid { get; set; } = null!;
        public int AddressTypeEntityId { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; }
        public DateTime InActivated { get; set; }
    }
}
