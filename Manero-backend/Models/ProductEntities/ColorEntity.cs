using System.ComponentModel.DataAnnotations;

namespace Manero_backend.Models.ProductEntities
{
    public class ColorEntity
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        
       // color kan har flere produkter
        public ICollection<ProductColorEntity> ProductColor { get; set; } = null!;
    }
}
