using Manero_backend.Context;
using Manero_backend.Interfaces.Cart;
using Manero_backend.Models.CartDto;
using Manero_backend.Models.CartsEntity;
using Microsoft.EntityFrameworkCore;

//Belal // ulius // Oscar
public class CartItemRepository : ICartItemRepository
{
    private readonly DataContext _dataContext;

    public CartItemRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CartItemResponseDTO> GetCartItemAsync(int cartItemId)
    {
        var cartItem = await _dataContext.CartItems.FindAsync(cartItemId);

        if (cartItem == null)
        {
            return null;
        }

        var cartItemDTO = new CartItemResponseDTO
        {
            Id = cartItem.Id,
            ProductId = cartItem.ProductId,
            Price = cartItem.Price,
            SizeId = cartItem.SizeId,
            ColorId = cartItem.ColorId,
            SKU = cartItem.SKU,
            Quantity = cartItem.Quantity,
        };

        return cartItemDTO;
    }

    public async Task<bool> CartItemExistsAsync(int cartItemId)
    {
        return await _dataContext.CartItems.AnyAsync(ci => ci.Id == cartItemId);
    }
}

