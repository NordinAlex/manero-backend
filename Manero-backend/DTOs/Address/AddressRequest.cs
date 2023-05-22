using Manero_backend.Factories;
using Manero_backend.Models.Addresses;
using System.ComponentModel.DataAnnotations;

namespace Manero_backend.DTOs.Address
{
    public class AddressRequest
    {
        [Required]
        public string TagName { get; set; } = null!;
        [Required]
        public string StreetName { get; set; } = null!;
        [Required]
        public string PostalCode { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool BillingAddress { get; set; }

        public static implicit operator AddressEntity(AddressRequest addressRequest)
        {
            var entity = AddressFactory.CreateEntity();
            entity.StreetName = addressRequest.StreetName;
            entity.PostalCode = addressRequest.PostalCode;
            entity.City = addressRequest.City;
            return entity;
        }

    }
}
