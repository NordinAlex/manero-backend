using System.ComponentModel.DataAnnotations;

namespace Manero_backend.Interfaces.Addresses.Model
{
    public interface IAddressRequest
    {
        public string TagName { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
