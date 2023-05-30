namespace Manero_backend.Interfaces.Users.Models
{
    public interface IUserAddressEntity
    {
        Guid Id { get; set; }
        public int AddressId { get; set; }
        public string Userid { get; set; }
        public int AddressTypeEntityId { get; set; } 
        public DateTime Created { get; set; }
        public bool Active { get; set; }
        public DateTime InActivated { get; set; }
    }
}
