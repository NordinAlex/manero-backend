using Manero_backend.Interfaces.Cart;
using Manero_backend.Services.CartRelatedServices;

namespace Manero_backend.Factories.CartRelatedFactories
{
    //Oscar, Belal
    public class ShoppingCartServiceFactory : IShoppingCartServiceFactory
    {
        private readonly ICartRepository _cartRepository;
        //  private readonly IMapper _mapper;

        public ShoppingCartServiceFactory(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            // _mapper = mapper;
        }

        public IShoppingCartService CreateShoppingCartService()
        {
            return new ShoppingCartService(_cartRepository);
        }
    }
}
