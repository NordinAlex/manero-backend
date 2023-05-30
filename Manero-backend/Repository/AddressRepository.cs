using Azure.Core;
using Manero_backend.Context;
using Manero_backend.DTOs.Address;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Addresses.Model;
using Manero_backend.Interfaces.Addresses.Repository;
using Manero_backend.Migrations.Identity;
using Manero_backend.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

namespace Manero_backend.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IdentityContext _identityContext;

        public AddressRepository(IdentityContext identityContext)
        {
            _identityContext = identityContext;
        }
        //USER ADDRESSES
        public async Task<UserAddressEntity> CreateUserAddressAsync(UserAddressEntity address)
        {
            try
            {
                _identityContext.UserAddress.Add(address);
                await _identityContext.SaveChangesAsync();
                return address;
            }
            catch
            {
                return null!;
            }

        }
        public async Task<UserAddressEntity> CheckBillingTrueAsync(string userId)
        {
            try
            {
                var result = await _identityContext.UserAddress.FirstOrDefaultAsync(x => x.Userid == userId && x.BillingAddress == true) ?? null!;
                if (result != null)   
                result.BillingAddress = !result.BillingAddress;
                return result!;
            }
            catch
            {
                return null!;
            }
        }

        public async Task<UserAddressEntity> GetUserAddressAsync(string userId, int addressId)
        {
            try
            {
                return await _identityContext.UserAddress.FirstOrDefaultAsync(x => x.Userid == userId && x.AddressId == addressId) ?? null!;
            }
            catch
            {
                return null!;
            }
        }
        public async Task<List<AddressResponse>> GetAllUserAddressesAsync(string userId)
        {
            try
            {
                var listResponse = new List<AddressResponse>();
                var query= from userAddress in _identityContext.UserAddress join addresses in _identityContext.Addresses on userAddress.AddressId equals addresses.Id where userAddress.Userid == userId select new { Column1 = userAddress, Column2 = addresses };
                var result = await query.ToListAsync();
                foreach (var item in result)
                {
                    var response = AddressFactory.CreateResponse();
                    response.StreetName = item.Column2.StreetName;
                    response.City = item.Column2.City;
                    response.PostalCode = item.Column2.PostalCode;
                    response.TagName = item.Column1.TagName;
                    response.BillingAddress = item.Column1.BillingAddress;
                    response.Active = item.Column1.Active;
                    listResponse.Add(response);
                }
                return listResponse;
            }
            catch { return null!; }
        }

        public async Task<UserAddressEntity> UpdateUserAddressAsync(UserAddressEntity userAddressEntity)
        {
            try 
            {
                _identityContext.Entry(userAddressEntity).State = EntityState.Modified;
                await _identityContext.SaveChangesAsync();
                return userAddressEntity;

            }
            catch
            {
                return null!;
            }
        }
        //ADDRESSES
        public async Task<AddressEntity> GetAddressAsync(AddressRequest request)
        {
            try
            {
                return await _identityContext.Addresses.FirstOrDefaultAsync(x => x.StreetName == request.StreetName && x.PostalCode == request.PostalCode && x.City == request.City)?? null!;
            }
            catch
            {
                return null!;
            }
        }
        public async Task<AddressEntity> CreateAddressAsync(AddressEntity address)
        {
            try
            {
                _identityContext.Addresses.Add(address);
                await _identityContext.SaveChangesAsync();
                return address;
            } catch
            {
                return null!;
            }
          
        }
    }
}