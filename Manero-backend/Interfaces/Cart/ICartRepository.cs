using Manero_backend.Models.CartDto;

namespace Manero_backend.Interfaces.Cart
{
    //Oscar, Belal
    public interface ICartRepository
    {

        Task<CartResponseDTO> GetCartByEmailAsync(string email);

        //Task<CartResponseDTO> GetCartByGuidAsync(Guid cartGuid);

        Task<int> CreateCartAsync(string email);

        Task<CartItemResponseDTO> AddCartItemAsync(int cartId, CartItemRequestDTO cartItemDto);

        Task<CartItemResponseDTO> UpdateCartItemAsync(int cartItemId, CartItemRequestDTO cartItemDto);

        Task RemoveCartItemAsync(int cartItemId);

        Task<int> ClearCartAsync(int cartId);
    }
}
