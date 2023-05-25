namespace Manero_backend.DTOs.Product
{
    public class SearchFilterResponse
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public List<string>? Tags { get; set; }
        public List<string>? Type { get; set; }
        public List<Variant>? Variants { get; set; }

        public class Variant
        {
            public string? SKU { get; set; }
            public string? Size { get; set; }
            public decimal? Price { get; set; }
            public List<string>? Color { get; set; }
        }
    }
}
