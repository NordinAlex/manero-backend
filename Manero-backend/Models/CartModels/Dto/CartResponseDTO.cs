namespace Manero_backend.Models.CartDto
{
    //Oscar //Julius // Belal
    public class CartResponseDTO
    {

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public ICollection<CartItemResponseDTO> Items { get; set; }
    }
}