using Manero_backend.Interfaces.Cart;
using Manero_backend.Models.CartDto;
using Manero_backend.Repository.CartRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Controllers
{
    //Oscar, Belal
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;


        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }



        /*   [HttpGet("{cartGuid}")]
           public async Task<ActionResult<CartResponseDTO>> GetCart(Guid cartGuid)
           {
               var cart = await _shoppingCartService.GetCartByGuidAsync(cartGuid);

               if (cart == null)
               {
                   return NotFound();
               }

               return Ok(cart);
           }
        /*
           /*    [HttpPost("{Email}")]
               public async Task<ActionResult<int>> CreateCart(string email)
               {
                 var cartEmail= email;
                var cartId = await _shoppingCartService.CreateCartAsync(email);
                return Ok(cartId);
               }
           */

        [HttpGet("{email}")]
        public async Task<ActionResult<CartResponseDTO>> GetCart(string email)
        {
            var cart = await _shoppingCartService.GetCartByEmailAsync(email);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }



        [HttpPost("{email}")]
        public async Task<ActionResult<int>> CreateCart(string email)
        {
            var cartId = await _shoppingCartService.CreateCartAsync(email);
            return Ok(cartId);
        }

        /*
        [HttpPost("{cartId}/items")]
        public async Task<ActionResult<CartItemResponseDTO>> AddCartItem(int cartId, [FromBody] CartItemRequestDTO cartItemDto)
        {
            var cartItem = await _shoppingCartService.AddCartItemAsync(cartId, cartItemDto);
            return Ok(cartItem);
        }
        */

        [HttpPost("{email}/items")]
        public async Task<ActionResult<CartItemResponseDTO>> AddCartItem(string email, [FromBody] CartItemRequestDTO cartItemDto)
        {
            var cartItem = await _shoppingCartService.AddCartItemAsync(email, cartItemDto);
            return Ok(cartItem);
        }


        [HttpPut("{cartItemId}")]
        public async Task<ActionResult<CartItemResponseDTO>> UpdateCartItem(int cartItemId, [FromBody] CartItemRequestDTO cartItemDto)
        {
            var cartItem = await _shoppingCartService.UpdateCartItemAsync(cartItemId, cartItemDto);
            return Ok(cartItem);
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> RemoveCartItem(int cartItemId)
        {
            await _shoppingCartService.RemoveCartItemAsync(cartItemId);
            return NoContent();
        }

        [HttpDelete("{cartId}/items")]
        public async Task<ActionResult<int>> ClearCart(int cartId)
        {
            var numDeleted = await _shoppingCartService.ClearCartAsync(cartId);
            return Ok(numDeleted);
        }
    }
}
