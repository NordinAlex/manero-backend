using System.ComponentModel.DataAnnotations;
using Manero_backend.Interfaces.Product.Models;

namespace Manero_backend.Models.ProductEntities
{
    public class ColorEntity : IColorEntity
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public string? ColorCode { get; set; }
    }
}
