namespace Manero_backend.Models.ProductEntities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!; 
        public string Type { get; set; } = null!;
        public SizeEntity Size { get; set; }= null!;
        public int SizeEntityid { get; set; }
        public int ProductImagesEntityid { get; set; }
        public ICollection<ProductImagesEntity> Images { get; set; } = null!;

        public int ProductTagsEntityid { get; set; }
        public ICollection<ProductTagsEntity> Tags { get; set; } = null!;
    }
}
