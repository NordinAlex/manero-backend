using Manero_backend.Context;
using Manero_backend.Interfaces.Cart;
using Manero_backend.Models.CartDto;
using Manero_backend.Models.CartsEntity;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Repository.CartRepository
{
    //Oscar, Belal
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<UserEntity> _userManager;

        public CartRepository(DataContext context, UserManager<UserEntity> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        /*   public async Task<CartResponseDTO> GetCartByIdAsync(int cartId)
           {
               var cart = await _context.Carts
                   .Include(x => x.User)
                   .Include(x => x.Items)
                       .ThenInclude(x => x.Product)
                   .Include(x => x.Items)
                       .ThenInclude(x => x.Size)
                   .Include(x => x.Items)
                       .ThenInclude(x => x.Color)
                   .FirstOrDefaultAsync(x => x.Id == cartId);

               if (cart == null)
               {
                   throw new ArgumentException($"Cart with ID {cartId} not found.");
               }

               return null!; //_mapper.Map<CartResponseDTO>(cart);
           }
        */

        public async Task<CartResponseDTO> GetCartByEmailAsync(string email)
        {
            var cart = await _context.Carts
                .Include(x => x.User)
                .Include(x => x.Items)
                    .ThenInclude(x => x.Product)
                .Include(x => x.Items)
                    .ThenInclude(x => x.Size)
                .Include(x => x.Items)
                    .ThenInclude(x => x.Color)
                .FirstOrDefaultAsync(x => x.User.Email == email);

            if (cart == null)
            {
                throw new ArgumentException($"Cart for user with email {email} not found.");
            }

            var cartResponse = new CartResponseDTO
            {
                // Map properties from CartEntity to CartResponseDTO
                Email = email,

                //Här ska resten vara
                // Map other properties as needed
            };

            return cartResponse;
        }

        /*
        public async Task<CartResponseDTO> GetCartByGuidAsync(Guid cartGuid)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Product)
                .Include(ci => ci.Items)
                .ThenInclude(ci => ci.Size)
                .Include(ci => ci.Items)
                .ThenInclude(ci => ci.Color)
                .FirstOrDefaultAsync(c => c.Id == cartGuid);

            if (cart == null)
            {
                throw new ArgumentException($"Cart with GUID {cartGuid} not found.");
            }

            return null!; // _mapper.Map<CartResponseDTO>(cart);
        }
        /*
        */
        /*
                public async Task<int> CreateCartAsync(Guid cartGuid, string userId)
                {
                    //Måste lägga in Dbset Users , Context hittar ej Users
                    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

                    if (user == null)
                    {
                        throw new ArgumentException($"User with ID {userId} not found.");
                    }

                    var cart = new CartEntity
                    {
                        Guid = cartGuid,
                        User = user,
                    };
                    try
                    {
                        _context.Carts.Add(cart);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex) { }

                    return cart.Id;
                }
        */
        
        public async Task<int> CreateCartAsync(string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                throw new ArgumentException($"User with email {email} not found.");
            }

            var cart = new CartEntity
            {
                User = user
            };

            try
            {
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
            }

            return cart.Id;
        }
        /*

        public async Task<CartItemResponseDTO> AddCartItemAsync(int cartId, CartItemRequestDTO cartItemDto)
        {
            var cart = await _context.Carts.FindAsync(cartId);

            if (cart == null)
            {
                throw new ArgumentException($"Cart with ID {cartId} not found.");
            }

            var product = await _context.Products.FindAsync(cartItemDto.ProductId);

            if (product == null)
            {
                throw new ArgumentException($"Product with ID {cartItemDto.ProductId} not found.");
            }

            var size = await _context.Sizes.FindAsync(cartItemDto.SizeId);

            if (size == null)
            {
                throw new ArgumentException($"Size with ID {cartItemDto.SizeId} not found.");
            }

            var color = await _context.Colors.FindAsync(cartItemDto.ColorId);

            if (color == null)
            {
                throw new ArgumentException($"Color with ID {cartItemDto.ColorId} not found.");
            }

            // Här måste jag ändra så att jag mappar ut hela CartItemEntity
            // Jag kommer behöva lägga till alla properties från CartItemEntity
            var cartItem = new CartItemEntity
            {
                Product = product,
                Size = size,
                Color = color,
                Quantity = cartItemDto.Quantity
            };

            cart.Items.Add(cartItem);
            await _context.SaveChangesAsync();

            return null!; // _mapper.Map<CartItemResponseDTO>(cartItem);
        }
        */

        public async Task<CartItemResponseDTO> AddCartItemAsync(string email, CartItemRequestDTO cartItemDto)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.Email == email);

            if (cart == null)
            {
                throw new ArgumentException($"Cart for email {email} not found.");
            }

            var product = await _context.Products.FindAsync(cartItemDto.ProductId);

            if (product == null)
            {
                throw new ArgumentException($"Product with ID {cartItemDto.ProductId} not found.");
            }

            var size = await _context.Sizes.FindAsync(cartItemDto.SizeId);

            if (size == null)
            {
                throw new ArgumentException($"Size with ID {cartItemDto.SizeId} not found.");
            }

            var color = await _context.Colors.FindAsync(cartItemDto.ColorId);

            if (color == null)
            {
                throw new ArgumentException($"Color with ID {cartItemDto.ColorId} not found.");
            }

            // Create a new cart item
            var cartItem = new CartItemEntity
            {
                Id = cart.Id,
                ProductId = product.Id,
                SizeId = size.Id,
                ColorId = color.Id,
                Quantity = cartItemDto.Quantity,
                
                
             //+ mappa ut resten
            };

            // Add the cart item to the database
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            // Map the cart item to the response DTO
            var responseDto = new CartItemResponseDTO
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                SizeId = cartItem.SizeId,
                ColorId = cartItem.ColorId,
                Quantity = cartItem.Quantity
            };

            return responseDto;
        }



        public async Task<CartItemResponseDTO> UpdateCartItemAsync(int cartItemId, CartItemRequestDTO cartItemDto)
        {
            //Satte db set på ResponseDto och RequestDto 
            //Vet ej exakt vad problemet 
            var cartItem = await _context.CartItems.FindAsync(cartItemId);

            if (cartItem == null)
            {
                throw new ArgumentException($"Cart item with ID {cartItemId} not found.");
            }

            var product = await _context.Products.FindAsync(cartItemDto.ProductId);

            if (product == null)
            {
                throw new ArgumentException($"Product with ID {cartItemDto.ProductId} not found.");
            }

            var size = await _context.Sizes.FindAsync(cartItemDto.SizeId);

            if (size == null)
            {
                throw new ArgumentException($"Size with ID {cartItemDto.SizeId} not found.");
            }

            var color = await _context.Colors.FindAsync(cartItemDto.ColorId);

            if (color == null)
            {
                throw new ArgumentException($"Color with ID {cartItemDto.ColorId} not found.");
            }

            cartItem.Product = product;
            cartItem.Size = size;
            cartItem.Color = color;
            cartItem.Quantity = cartItemDto.Quantity;

            _context.Update(cartItem);
            await _context.SaveChangesAsync();

            return null!; // _mapper.Map<CartItemResponseDTO>(cartItem);
        }

        public async Task RemoveCartItemAsync(int cartItemId)
        {
            //Måste lägga en DBset så att context hittar Cart, kanske måste ändra namnet på CartItems
            //
            var cartItem = await _context.CartItems.FindAsync(cartItemId);

            if (cartItem == null)
            {
                throw new ArgumentException($"Cart item with ID {cartItemId} not found.");
            }

            _context.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task<int> ClearCartAsync(int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);

            if (cart == null)
            {
                throw new ArgumentException($"Cart with ID {cartId} not found.");
            }

            cart.Items.Clear();
            await _context.SaveChangesAsync();

            return cart.Id;
        }

        //Här ska resterande metoder vara
    }
}
