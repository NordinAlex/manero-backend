using System.ComponentModel.DataAnnotations;

namespace Manero_backend.Models.ProductEntities
{
    public class ColorEntity
    {    
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public string? ColorCode { get; set; }   
        
        public int ProductColorEntityid { get; set; } // color kan har flere produkter
        public ProductColorEntity Product { get; set; } = null!;
    }
}
