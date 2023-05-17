using Manero_backend.Interfaces.Order;

namespace Manero_backend.BaseModels.Order
{
    public abstract class OrderBase : IOrder
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
    }
}
