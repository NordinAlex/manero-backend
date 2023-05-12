namespace Manero_backend.Interfaces.Order
{
    public interface IOrder
    {
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
