using Manero_backend.DTOs.Address;
using Manero_backend.Models.Addresses;
using Manero_backend.Models.UserEntities;
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
        //Addresses
        public AddressRequest ValidAddressCreateRequest { get; }
        public AddressRequest InvalidAddressCreateRequest { get; }
        public AddressResponse ValidAddressCreateResponse { get; }
        public AddressResponse InvalidAddressCreateResponse { get; }
        public AddressResponse ValidGetAllAddressForOneUserResponse { get; }

        //User
        public UserEntity ValidUserEntity { get; }
        public UserEntity InvalidUserEntity { get; }
        public UserAddressEntity ValidUserAddressEntity { get; }
        public UserAddressEntity InvalidUserAddressEntity { get; }
        public UserAddressEntity ValidUserAddressEntityAsBillingAddress { get; }
        public UserAddressEntity ValidUserAddressEntityFalseBillingAddress { get; }

        public AddressFixture()
        {
            //Address
            ValidAddressCreateRequest = new AddressRequest
            {
                TagName = "Home",
                StreetName = "123 Main St",
                PostalCode = "12345",
                City = "City",
                BillingAddress = true,
                Email = "patrik.byren@hotmail.com"
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

            //User
            ValidUserEntity = new UserEntity
            {
                FirstName = "John",
                LastName = "Doe",
                CreatedBy = "MANERO",
            };
            InvalidUserEntity = new UserEntity
            {

            };
            ValidUserAddressEntity = new UserAddressEntity
            {
                Id = Guid.NewGuid(),
                AddressId = 1,
                Userid = "1",
                BillingAddress = true,
                TagName = "Home",
                Created = DateTime.Now,
                Active = true,
            };
            InvalidUserAddressEntity = new UserAddressEntity
            {

            };
            ValidUserAddressEntityAsBillingAddress = new UserAddressEntity
            {
                Id = Guid.NewGuid(),
                AddressId = 1,
                Userid = "1",
                BillingAddress = true,
                TagName = "Home",
                Created = DateTime.Now,
                Active = true,
            };
            ValidUserAddressEntityFalseBillingAddress = new UserAddressEntity
            {
                Id = Guid.NewGuid(),
                AddressId = 1,
                Userid = "1",
                BillingAddress = true,
                TagName = "Home",
                Created = DateTime.Now,
                Active = false
            };
        }
    }
}

