using System.ComponentModel.DataAnnotations;

namespace Manero_backend.Models.ProductEntities
{
    public class BrandEntity
    {
        [Key]
        public int Id { get; set; }        
        public string BrandName { get; set; } = null!;
        public string? BrandCode { get; set; }
    }
}
