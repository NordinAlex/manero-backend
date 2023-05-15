using Manero_backend.BaseModels.Order;
using Manero_backend.DTOs.ProductItem;
using Manero_backend.Interfaces.Order;
using Manero_backend.Models.ProductItemEntities;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.DTOs.Order
{
    public class OrderResponse : OrderBase, IOrderResponse
    {
        public List<ProductItemOrderRequestModel> ProductItems { get; set; } = null!;
    }
}
