namespace Manero_backend.DTOs.Product
{
    public class ProductItemResponse  // Product Variation
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SKU { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Size { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
   
        public ICollection<string>? ImageAlt { get; set; }
        public ICollection<string>? ImageName { get; set; }       
    }
}
