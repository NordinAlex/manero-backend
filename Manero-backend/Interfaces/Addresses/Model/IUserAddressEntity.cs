namespace Manero_backend.Interfaces.Addresses.Model
{
    public interface IUserAddressEntity
    {
        public Guid Id { get; set; }
        public int AddressId { get; set; }
        public string Userid { get; set; } 
        public bool BillingAddress { get; set; }
        public string TagName { get; set; } 
        public DateTime Created { get; set; }
        public bool Active { get; set; }
        public DateTime InActivated { get; set; }
    }
}
