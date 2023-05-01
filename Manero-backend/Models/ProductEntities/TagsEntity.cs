namespace Manero_backend.Models.ProductEntities
{
    public class TagsEntity
    {
        public int Id { get; set; }
        public string Tag { get; set; } = null!;

        public ICollection<ProductTagsEntity> ProductTags { get; set; } = null!; // tag kan ha flera produkter
    }
}
