namespace Manero_backend.Models.ProductEntities
{
    public class ProductSizeEntity
    {
        public int ProductEntityId { get; set; }
        public ProductEntity ProductEntity { get; set; } = null!;
        public int SizeEntityId { get; set; }
        public SizeEntity SizeEntity { get; set; } = null!;
    }
}
