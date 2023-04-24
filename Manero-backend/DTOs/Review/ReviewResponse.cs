namespace Manero_backend.DTOs.Review
{
    public class ReviewResponse
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
