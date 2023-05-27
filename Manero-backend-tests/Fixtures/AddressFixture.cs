using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Manero_backend_tests.Fixtures
{
    public class AddressFixture
    {
        
        public AddressRequest ValidAddressCreateRequest { get; }
        public AddressRequest InvalidAddressCreateRequest { get; }
        public AddressResponse ValidAddressCreateResponse { get; }
        public AddressResponse InvalidAddressCreateResponse { get; }
        public AddressResponse ValidGetAllAddressForOneUserResponse { get; }

        public class AddressRequest
        {
            public string? TagName { get; set; }
            public string? StreetName { get; set; } 
            public string? PostalCode { get; set; }
            public string? City { get; set; }
            public string? Email { get; set; }
            public bool BillingAddress { get; set; }
        }
        public class AddressResponse
        {
            public string? StreetName { get; set; }
            public string? City { get; set; }
            public string? PostalCode { get; set; }
            public string? StatusMessage { get; set; }
            public bool Error { get; set; }
            public string? TagName { get; set; }
            public bool BillingAddress { get; set; }
            public bool Active { get; set; }
            public ICollection<AddressResponse>? AddressList { get; set; }
        }
        public AddressFixture()
        {
            ValidAddressCreateRequest = new AddressRequest
            {
                TagName = "Home",
                StreetName = "123 Main St",
                PostalCode = "12345",
                City = "City",
                BillingAddress = true
            };

            InvalidAddressCreateRequest = new AddressRequest
            {

            };

            ValidAddressCreateResponse = new AddressResponse
            {
                StreetName = "123 Main St",
                City = "City",
                PostalCode = "12345",
                Active = true,
                TagName = "Home",
                BillingAddress = true

            };

            InvalidAddressCreateResponse = new AddressResponse
            {
                StatusMessage = "Error",
                Error = true
            };
            ValidGetAllAddressForOneUserResponse = new AddressResponse
            {
                AddressList = new List<AddressResponse>
                {
                    new AddressResponse
                    {
                        StreetName = "123 Main St 1",
                        City = "City 1",
                        PostalCode = "12345",
                        Active = true,
                        TagName = "Home",
                        BillingAddress = true
                    },
                    new AddressResponse
                    {
                        StreetName = "123 Main St 2",
                        City = "City 2",
                        PostalCode = "12345",
                        Active = true,
                        TagName = "Work",
                        BillingAddress = false
                    }
                }

            };
        }
    }
}

