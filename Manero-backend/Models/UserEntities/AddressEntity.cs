namespace Manero_backend.Models.UserEntities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string? City { get; set; }

        public ICollection<UserAddressEntity> UserAddresses { get; set; } = new HashSet<UserAddressEntity>();
    }
}
