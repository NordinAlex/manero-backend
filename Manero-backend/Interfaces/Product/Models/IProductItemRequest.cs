namespace Manero_backend.Interfaces.Product.Models
{
    public interface IProductItemRequest
    {
        int Color { get; set; }
        ICollection<string>? ImageAlt { get; set; }
        ICollection<string>? ImageName { get; set; }
        decimal Price { get; set; }
        int Size { get; set; }
        int Stock { get; set; }
    }
}