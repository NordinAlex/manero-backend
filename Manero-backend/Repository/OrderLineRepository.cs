using Manero_backend.Context;
using Manero_backend.Interfaces.OrderLine;
using Manero_backend.Models.OrderEntities;

namespace Manero_backend.Repository
{
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly DataContext _context;

        public OrderLineRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(OrderLineEntity orderLine)
        {
            try
            {
                _context.OrderLines.Add(orderLine);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
