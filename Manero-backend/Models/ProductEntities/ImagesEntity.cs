using Manero_backend.Models.ProductItemEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero_backend.Models.ProductEntities
{
    public class ImagesEntity
    {
        public int Id { get; set; }
        public string? ImageAlt { get; set; }
        public string? ImageName { get; set; }
        public ProductItemEntity? ProductItemEntity { get; set; }

    }
}
