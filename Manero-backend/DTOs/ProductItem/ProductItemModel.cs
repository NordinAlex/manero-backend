using Manero_backend.Interfaces.ProductItem;
using Manero_backend.Models.ProductEntities;

namespace Manero_backend.DTOs.ProductItem
{
    public class ProductItemOrderRequestModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal LinePrice
        {
            get
            {
               return Quantity * Price;
            }
        }
    }
}
