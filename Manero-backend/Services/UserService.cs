using Manero_backend.Context;
using Manero_backend.DTOs.Product;
using Manero_backend.DTOs.User;
using Manero_backend.Interfaces.Product.Services;
using Manero_backend.Migrations.Data;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.UserEntities;
using Manero_backend.Repository;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace Manero_backend.Services
{

    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> CreateUserAsync(UserRequest userRequest)
        {
            // Skapa en ny User-instans baserad på uppgifterna i UserRequest-objektet
            var user = new UserRequest
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                Location = userRequest.Location,
            };

            // Anropa en metod i UserRepository för att spara den nya användaren i databasen
            var savedUser = await _userRepository.CreateAsync(user);

            // Skapa en ny UserResponse-instans baserad på den sparade användaren
            var userResponse = new UserResponse
            {
                Id = savedUser.Id,
                FirstName = savedUser.FirstName,
                LastName = savedUser.LastName,
                Email = savedUser.Email,

            };


            return userResponse;
        }


    }
}



