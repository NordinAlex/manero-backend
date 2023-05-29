using Manero_backend.Interfaces.Product.Models;

namespace Manero_backend.Models.ProductEntities
{
    public class ProductTypeEntity : IProductTypeEntity
    {
        public int ProductEntityId { get; set; }
        public ProductEntity ProductEntity { get; set; } = null!;
        public int TypeEntityId { get; set; }
        public TypeEntity TypeEntity { get; set; } = null!;
    }
}
