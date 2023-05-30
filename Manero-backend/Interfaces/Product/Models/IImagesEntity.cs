using Manero_backend.Models.ProductItemEntities;

namespace Manero_backend.Interfaces.Product.Models
{
    public interface IImagesEntity
    {
        int Id { get; set; }
        string? ImageAlt { get; set; }
        string? ImageName { get; set; }
        ProductItemEntity? ProductItemEntity { get; set; }
    }
}