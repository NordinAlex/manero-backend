using Manero_backend.Interfaces.OrderLine;
using Manero_backend.Models.OrderEntities;

namespace Manero_backend.Repository
{
    public class OrderLineRepository : IOrderLineRepository
    {
        public Task<bool> CreateAsync(OrderLineEntity orderLine)
        {
            throw new NotImplementedException();
        }
    }
}
