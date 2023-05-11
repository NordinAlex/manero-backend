using Manero_backend.Context;
using Manero_backend.DTOs.Order;
using Manero_backend.Interfaces.Order;
using Manero_backend.Models.OrderEntities;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<OrderEntity> CreateOrderAsync(OrderEntity orderEntity)
        {
            try
            {
                _context.Orders.Add(orderEntity);
                await _context.SaveChangesAsync();
                return orderEntity;
            }

            catch (Exception ex)
            {
                return null!;
            }
        }

        public async Task<bool> DeleteOrderAsync(OrderEntity orderEntity)
        {
            try
            {
                _context.Orders.Remove(orderEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<OrderEntity> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            return order!;
        }
    }
}
