using System.ComponentModel.DataAnnotations;
using Manero_backend.Interfaces.Product.Models;

namespace Manero_backend.Models.ProductEntities
{
    public class BrandEntity : IBrandEntity
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; } = null!;
        public string? BrandCode { get; set; }
    }
}
