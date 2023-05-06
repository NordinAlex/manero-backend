using Manero_backend.Models.OrderEntities;

namespace Manero_backend.Interfaces.OrderLine
{
    public interface IOrderLineRepository
    {
        Task<bool> CreateAsync(OrderLineEntity orderLine);
    }
}
