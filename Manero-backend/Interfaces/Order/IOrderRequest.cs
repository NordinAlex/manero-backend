using Manero_backend.DTOs.ProductItem;
using Manero_backend.Models.ProductItemEntities;

namespace Manero_backend.Interfaces.Order
{
    public interface IOrderRequest : IOrderWithAddressId
    {
        public List<ProductItemOrderRequestModel> ProductItems { get; set; }
    }
}
