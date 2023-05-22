using Manero_backend.DTOs.Address;
using Manero_backend.DTOs.User;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Addresses.Model;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Manero_backend.Models.Addresses
{
    public class AddressEntity : IAddressEntity
    {
        public int Id { get; set; }
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

    }
}
