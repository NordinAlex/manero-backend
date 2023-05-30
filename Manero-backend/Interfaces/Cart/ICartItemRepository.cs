using Manero_backend.Models.CartDto;

namespace Manero_backend.Interfaces.Cart
{
    public interface ICartItemRepository
    {
        Task<CartItemResponseDTO> GetCartItemAsync(int cartItemId);
        Task<bool> CartItemExistsAsync(int cartItemId);
    }
}
