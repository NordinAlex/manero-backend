using Manero_backend.Interfaces.Users.Models;
using System.Runtime.CompilerServices;

namespace Manero_backend.Models.UserEntities
{
    public class AddressEntity : IAddressEntity
    {
        public int Id { get; set; }
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string? City { get; set; }
    }
}
