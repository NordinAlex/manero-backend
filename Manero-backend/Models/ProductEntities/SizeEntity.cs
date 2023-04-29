namespace Manero_backend.Models.ProductEntities
{
    public class SizeEntity
    {
        public int Id { get; set; }
        public string Size { get; set; } = null!;
        public int SizeQuantity { get; set; }

        public ICollection<ProductSizeEntity> ProductSize { get; set; } = null!; // size kan ha flera produkter
    }
}
