using Manero_backend.Interfaces.Cart;

namespace Manero_backend.Factories.CartRelatedFactories
{
    //Oscar och Belal
    public interface IFactory
    {
        IShoppingCartService GetCartService();
    }
}

