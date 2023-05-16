using Manero_backend.DTOs.ProductItem;
using Manero_backend.Models.ProductItemEntities;

namespace Manero_backend.Interfaces.Order
{
    public interface IOrderRequest : IOrder
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public List<ProductItemOrderModel> ProductItems { get; set; }
    }
}
