namespace Manero_backend.Models.ProductEntities
{
    public class promocodesEntity
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public decimal Discount { get; set; }
        public int Quantity { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
