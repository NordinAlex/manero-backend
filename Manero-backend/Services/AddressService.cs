using Manero_backend.DTOs.Address;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Addresses.Repository;
using Manero_backend.Interfaces.Addresses.Service;
using Manero_backend.Models.Addresses;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly UserManager<UserEntity> _userManager;

        public AddressService(IAddressRepository addressRepository, UserManager<UserEntity> userManager)
        {
            _addressRepository = addressRepository;
            _userManager = userManager;
        }


        //USER ADDRESSES
        public async Task<AddressResponse> CreateAddressAsync(AddressRequest request)
        {
            var userEntity = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.Email);
            if(userEntity == null) //Hämtar ID på User och kollar att den finns
            {
                return AddressFactory.CreateResponse("Unexpected error! Could not find user.", true); 
            }
            var addressEntity = await _addressRepository.GetAddressAsync(request); //
            if (addressEntity != null!) //Hämtar ID på addressen och kollar att den finns
            {
                var userAddressEntity = await _addressRepository.GetUserAddressAsync(userEntity.Id , addressEntity.Id);
                if(userAddressEntity != null) //Kollar om vår User är kopplad till addressen
                {
                    if (userAddressEntity.TagName != request.TagName || userAddressEntity.BillingAddress != request.BillingAddress)
                    { //Kollar om den har bytt tagname eller billing address
                        if (userAddressEntity.TagName != request.TagName )
                        { // om tag name är bytt sätt den nya tagname
                            userAddressEntity.TagName = request.TagName;
                        }
                        if (userAddressEntity.BillingAddress != request.BillingAddress)
                        { // om billing är bytt sätt den nya billing
                            var billingAddress = await _addressRepository.CheckBillingTrueAsync(userEntity.Id);
                            if (billingAddress != null)  // kolla att det inte finns andra billing addresssen i db (MAN KAN ENDAST HA 1)
                            { var result = await _addressRepository.UpdateUserAddressAsync(billingAddress); }
                        }
                        userAddressEntity.BillingAddress = request.BillingAddress;
                        var updateResponse = await _addressRepository.UpdateUserAddressAsync(userAddressEntity); // Updatera USERADDRESS
                        if(updateResponse != null!)
                        {
                            var result = await _addressRepository.UpdateUserAddressAsync(userAddressEntity);
                            return AddressFactory.CreateResponse(addressEntity.StreetName, addressEntity.PostalCode, addressEntity.City, userAddressEntity.TagName);}
                        else { return AddressFactory.CreateResponse("Unexpected error! Error while updating", true); }
                    }
                }
                else { 
                    if (request.BillingAddress == true)
                        {
                        var billingAddress = await _addressRepository.CheckBillingTrueAsync(userEntity.Id);
                        if (billingAddress != null) 
                            {
                                var updateResponse = await _addressRepository.UpdateUserAddressAsync(billingAddress); 
                            }
                        }
                    var userAddressCreatedEntity = AddressFactory.CreateUserAddressEntity(addressEntity.Id, userEntity.Id, request.BillingAddress, request.TagName);
                    var userAddressCreatedResponse = await _addressRepository.CreateUserAddressAsync(userAddressCreatedEntity);
                    }
            }
            else
            {
                if (request.BillingAddress == true)
                {
                    var billingAddress = await _addressRepository.CheckBillingTrueAsync(userEntity.Id);
                    if (billingAddress != null)
                    {
                        var updateResponse = await _addressRepository.UpdateUserAddressAsync(billingAddress);
                    }
                }
                addressEntity = await _addressRepository.CreateAddressAsync(request);
                if(addressEntity != null)
                {
                    var userAddressCreatedEntity = AddressFactory.CreateUserAddressEntity(addressEntity.Id, userEntity.Id, request.BillingAddress, request.TagName);
                    var databaseRespons = await _addressRepository.CreateUserAddressAsync(userAddressCreatedEntity);
                    if(databaseRespons != null)
                    {
                        return AddressFactory.CreateResponse(addressEntity.StreetName, addressEntity.PostalCode, addressEntity.City, userAddressCreatedEntity.TagName);
                    }
                }
            }
            return AddressFactory.CreateResponse("Vet ej",true);
        }

        //ADDRESSES
        public async Task<AddressEntity> GetAsync(AddressRequest request)
        {
            var result = await _addressRepository.GetAddressAsync(request);
            return result;
        }
        public async Task<AddressResponse> GetAllForOneUserAsync(string email)
        {

            return null!;
        }
        public async Task<AddressResponse> RemoveAddressFromUser(AddressRequest request)
        {
            return null!;
        }
    }
}
