namespace Manero_backend.Interfaces.Order
{
    public interface IOrderWithAddressId : IOrder
    {
        public int ShippingAddressId { get; set; }
    }
}
