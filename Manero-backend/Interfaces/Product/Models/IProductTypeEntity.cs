using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Models
{
    public interface IProductTypeEntity
    {
        ProductEntity ProductEntity { get; set; }
        int ProductEntityId { get; set; }
        TypeEntity TypeEntity { get; set; }
        int TypeEntityId { get; set; }
    }
}