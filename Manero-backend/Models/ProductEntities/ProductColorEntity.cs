namespace Manero_backend.Models.ProductEntities
{
    public class ProductColorEntity
    {
        public int ProductEntityId { get; set; }
        public ProductEntity ProductEntity { get; set; } = null!;
        public int ColorEntityId { get; set; }
        public ColorEntity ColorEntity { get; set; } = null!;
    }
}
