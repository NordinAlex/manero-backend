using Azure.Core;
using Manero_backend.DTOs.Address;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Addresses.Repository;
using Manero_backend.Interfaces.Addresses.Service;
using Manero_backend.Models.Addresses;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
            #region Hämtar Adress och Användare och kontrollerar att de finns 
            UserEntity? userEntity = await GetUserEntityAsync(request);
            if (userEntity == null) //Hämtar ID på User och kollar att den finns
            {
                return AddressFactory.CreateResponse("Unexpected error! Could not find user.", true);
            }
            var addressEntity = await _addressRepository.GetAddressAsync(request);
            if (addressEntity != null!) //Hämtar ID på addressen och kollar att den finns
            {
                #endregion
                #region Kollar om en UserAddress redan finns kopplad till användaren. Om så, uppdaterar denna.
                var userAddressEntity = await _addressRepository.GetUserAddressAsync(userEntity.Id, addressEntity.Id);
                if (userAddressEntity != null) //Kollar om vår User är kopplad till addressen
                {
                    #region Kollar om den är useraddress är active // EJ TESTAD ÄNNU PB
                    if (!userAddressEntity.Active)
                    {
                        if (request.BillingAddress)
                        {
                            var billingAddress = await _addressRepository.CheckBillingTrueAsync(userEntity.Id);
                            if (billingAddress != null)  // kolla att det inte finns andra billing addresssen i db (MAN KAN ENDAST HA 1)
                            { var result = await _addressRepository.UpdateUserAddressAsync(billingAddress); }
                            var userAddressCreatedEntity = AddressFactory.CreateUserAddressEntity(addressEntity.Id, userEntity.Id, request.BillingAddress, request.TagName);
                            var databaseRespons = await _addressRepository.CreateUserAddressAsync(userAddressCreatedEntity);
                            if (databaseRespons != null)
                            {
                                return AddressFactory.CreateResponse(addressEntity.StreetName, addressEntity.PostalCode, addressEntity.City, userAddressCreatedEntity.TagName);
                            }
                        }
                    }
                    #endregion
                    if (userAddressEntity.TagName != request.TagName || userAddressEntity.BillingAddress != request.BillingAddress)
                    { //Kollar om den har bytt tagname eller billing address
                        if (userAddressEntity.TagName != request.TagName)
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
                        if (updateResponse != null!)
                        {
                            return AddressFactory.CreateResponse(addressEntity.StreetName, addressEntity.PostalCode, addressEntity.City, userAddressEntity.TagName);
                        }
                        else { return AddressFactory.CreateResponse("Unexpected error! Error while updating", true); }
                    }
                }
                #endregion
                #region Om Adressen finns men ingen UserAddress så skapa UserAddress och koppla dessa.
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
                    var userAddressCreatedEntity = AddressFactory.CreateUserAddressEntity(addressEntity.Id, userEntity.Id, request.BillingAddress, request.TagName);
                    var userAddressCreatedResponse = await _addressRepository.CreateUserAddressAsync(userAddressCreatedEntity);
                    return AddressFactory.CreateResponse(addressEntity.StreetName, addressEntity.PostalCode, addressEntity.City, userAddressCreatedResponse.TagName);
                }
                #endregion
                #region Om Adressen inte finns: skapa Address och UserAddress
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
                if (addressEntity != null)
                {
                    var userAddressCreatedEntity = AddressFactory.CreateUserAddressEntity(addressEntity.Id, userEntity.Id, request.BillingAddress, request.TagName);
                    var databaseRespons = await _addressRepository.CreateUserAddressAsync(userAddressCreatedEntity);
                    if (databaseRespons != null)
                    {
                        return AddressFactory.CreateResponse(addressEntity.StreetName, addressEntity.PostalCode, addressEntity.City, userAddressCreatedEntity.TagName);
                    }
                }
            }
            #endregion
            return AddressFactory.CreateResponse("Unexpected Error", true);
        }

        private async Task<UserEntity?> GetUserEntityAsync(AddressRequest request)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.Email);
        }

        //ADDRESSES
        public async Task<AddressEntity> GetAsync(AddressRequest request)
        {
            var result = await _addressRepository.GetAddressAsync(request);
            return result;
        }
        public async Task<AddressResponse> GetAllForOneUserAsync(string email)
        {
            try
            {
                var userEntity = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == email);
                if (userEntity == null) //Hämtar ID på User och kollar att den finns
                {
                    return AddressFactory.CreateResponse("Unexpected error! Could not find user.", true);
                }
                var listResponse = await _addressRepository.GetAllUserAddressesAsync(userEntity.Id);
                if(listResponse != null && listResponse!.Count != 0)
                {
                    return AddressFactory.CreateResponse(listResponse.OrderByDescending(x => x.BillingAddress).Where(x => x.Active == true).ToList());
                }
            }catch (Exception ex) { }
            return AddressFactory.CreateResponse("There were no addresses or an unexpected error occured in the database",true);
        }
        public async Task<AddressResponse> InActivateAddressAsync(AddressRequest request)
        {
            var userEntity = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.Email);
            if (userEntity == null) //Hämtar ID på User och kollar att den finns
            {
                return AddressFactory.CreateResponse("Unexpected error! Could not find user.", true);
            }
            var addressEntity = await _addressRepository.GetAddressAsync(request);
            if (addressEntity != null!) //Hämtar ID på addressen och kollar att den finns
            {
                var userAddressEntity = await _addressRepository.GetUserAddressAsync(userEntity.Id, addressEntity.Id);
                if (userAddressEntity != null)
                {
                    userAddressEntity.Active = false;
                    userAddressEntity.InActivated = DateTime.Now;
                    var updateResponse = await _addressRepository.UpdateUserAddressAsync(userAddressEntity);
                    if (updateResponse != null)
                    {
                        return AddressFactory.CreateResponse("Address was succesfully removed", false);
                    }
                }
            }
            return AddressFactory.CreateResponse("Unexpected error", true);
        }
    }
}
