namespace Manero_backend.DTOs.Product
{
    public class SearchFilterRequest
    {
        public string? Name { get; set; }
        public List<string>? Color { get; set; }
        public string? SKU { get; set; }
        public string? Size { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<string>? Type { get; set; }
        public List<string>? Tags { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
    }
}
