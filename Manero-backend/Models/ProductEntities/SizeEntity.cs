using System.ComponentModel.DataAnnotations;
using Manero_backend.Interfaces.Product.Models;

namespace Manero_backend.Models.ProductEntities
{
    public class SizeEntity : ISizeEntity
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; } = null!;

    }
}
