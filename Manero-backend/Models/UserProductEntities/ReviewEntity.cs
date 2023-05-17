using System.ComponentModel.DataAnnotations;

namespace Manero_backend.Models.UserProductEntities
{
    public class ReviewEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Comment { get; set; }     
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int ProductEntityId { get; set; }
    }
}
