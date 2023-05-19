using Manero_backend.Models.UserEntities;

namespace Manero_backend.Interfaces.Addresses.Model
{
    public interface IAddressEntity
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
