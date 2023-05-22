namespace Manero_backend.Interfaces.Addresses.Model
{
    public interface IAddressResponse
    {
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StatusMessage { get; set; }
        public bool Error { get; set; }
        public string TagName { get; set; }
    }
}
