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

        public async Task<AddressResponse> CreateAddressAsync(AddressRequest request)
        {
            var userEntity = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.Email);
            if(userEntity == null)
            {
                return AddressFactory.CreateResponse("Unexpected error! Could not find user.", true);
            }
            var addressEntity = await _addressRepository.GetAsync(request);
            if (addressEntity != null!)
            {
                var userAddressEntity = await _addressRepository.GetUserAddressAsync(userEntity.Id , addressEntity.Id);
                if(userAddressEntity != null)
                {
                    if(userAddressEntity.TagName != request.TagName)
                    {

                    }
                }
            }
            return null!;
        }

        public async Task<AddressEntity> GetAsync(AddressRequest request)
        {
            var result = await _addressRepository.GetAsync(request);
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
