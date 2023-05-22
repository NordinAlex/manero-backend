namespace Manero_backend.Models.CartDto
{
    //Oscar // Julius // Belal
    public class CartItemRequestDTO
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
