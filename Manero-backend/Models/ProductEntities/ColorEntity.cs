using System.ComponentModel.DataAnnotations;

namespace Manero_backend.Models.ProductEntities
{
    public class ColorEntity
    {    
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public string? ColorCode { get; set; }   
        
       // color kan har flere produkter
        public ICollection<ProductColorEntity> ProductColors { get; set; } 
    }
}
