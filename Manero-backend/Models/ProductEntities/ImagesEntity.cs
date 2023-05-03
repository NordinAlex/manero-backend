using System.ComponentModel.DataAnnotations.Schema;

namespace Manero_backend.Models.ProductEntities
{
    public class ImagesEntity
    {
        public int Id { get; set; }
        public string? ImageAlt { get; set; }
        public string? ImageName { get; set; }      

        public int ProductEntityid { get; set; }
        public ProductEntity? Product { get; set; } // image kan ha en produkt
    }
}
