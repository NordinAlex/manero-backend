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
        public string? Email { get; set; }
    }
}
