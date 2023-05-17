namespace Manero_backend.Models.ProductEntities
{
    public class ProductTagsEntity
    {
        public int ProductEntityId { get; set; }
        public ProductEntity ProductEntity { get; set; } = null!;
        public int TagsEntityId { get; set; }
        public TagsEntity TagsEntity { get; set; } = null!;
    }
}
