using Manero_backend.Models.CartDto;

namespace Manero_backend.Interfaces.Cart
{
    //Oscar, Belal
    //Flytta denna till Interface Mappen
    public interface IShoppingCartService
    {
        Task<int> CreateCartAsync(string email);
        Task<CartResponseDTO> GetCartByEmailAsync(string email);

        // Task<CartItemResponseDTO> AddCartItemAsync(int cartId, CartItemRequestDTO cartItemDto);
        Task<CartItemResponseDTO> AddCartItemAsync(string email, CartItemRequestDTO cartItemDto);

        Task<CartItemResponseDTO> UpdateCartItemAsync(int cartItemId, CartItemRequestDTO cartItemDto);
        Task RemoveCartItemAsync(int cartItemId);
        Task<int> ClearCartAsync(int cartId);
    }
}
