using Manero_backend.Interfaces.Cart;
using Manero_backend.Models.CartDto;
using System.Web.Helpers;

namespace Manero_backend.Services.CartRelatedServices
{
    //Oscar och Belal
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ICartRepository _cartRepository;
        //  private readonly IMapper _mapper;

        public ShoppingCartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            //    _mapper = mapper;
        }

        public async Task<CartResponseDTO> GetCartByEmailAsync(string email)
        {
            return await _cartRepository.GetCartByEmailAsync(email);
        }

        public async Task<int> CreateCartAsync(string email)
        {
            // Perform any necessary validation or additional logic here

            return await _cartRepository.CreateCartAsync(email);
        }

        /*
        public async Task<CartItemResponseDTO> AddCartItemAsync(int cartId, CartItemRequestDTO cartItemDto)
        {
            return await _cartRepository.AddCartItemAsync(cartId, cartItemDto);
        }
        */
        public async Task<CartItemResponseDTO> AddCartItemAsync(string email, CartItemRequestDTO cartItemDto)
        {
            var cart = await _cartRepository.GetCartByEmailAsync(email);

            if (cart == null)
            {
                throw new ArgumentException("Cart not found.");
            }

            // Update the cartId parameter to use the retrieved cart's ID
            return await _cartRepository.AddCartItemAsync(cart.Id.ToString(), cartItemDto);

        }


        public async Task<CartItemResponseDTO> UpdateCartItemAsync(int cartItemId, CartItemRequestDTO cartItemDto)
        {
            return await _cartRepository.UpdateCartItemAsync(cartItemId, cartItemDto);
        }

        public async Task RemoveCartItemAsync(int cartItemId)
        {
            await _cartRepository.RemoveCartItemAsync(cartItemId);
        }

        public async Task<int> ClearCartAsync(int cartId)
        {
            return await _cartRepository.ClearCartAsync(cartId);
        }


        // Add any additional methods that the shopping cart service should have here
    }
}
