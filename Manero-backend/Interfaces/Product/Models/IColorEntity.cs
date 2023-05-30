namespace Manero_backend.Interfaces.Product.Models
{
    public interface IColorEntity
    {
        string Color { get; set; }
        string? ColorCode { get; set; }
        int Id { get; set; }
    }
}