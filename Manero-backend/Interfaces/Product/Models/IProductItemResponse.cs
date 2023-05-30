namespace Manero_backend.Interfaces.Product.Models
{
    public interface IProductItemResponse
    {
        string Color { get; set; }
        int Id { get; set; }
        ICollection<string>? ImageAlt { get; set; }
        ICollection<string>? ImageName { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        string Size { get; set; }
        string SKU { get; set; }
        int Stock { get; set; }
    }
}