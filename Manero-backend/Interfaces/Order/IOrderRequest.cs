using Manero_backend.Models.ProductItemEntities;

namespace Manero_backend.Interfaces.Order
{
    public interface IOrderRequest : IOrder
    {
        public List<ProductItemEntity> ProductItems { get; set; }
    }
}
