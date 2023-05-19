using Azure.Core;
using Manero_backend.DTOs.User;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Users.Models;
using Manero_backend.Interfaces.Users.Repositories;
using Manero_backend.Interfaces.Users.Service;
using Manero_backend.Migrations.Identity;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Manero_backend.Services
{
    public class AuthServices : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly TokenService _tokenService;

        public AuthServices(IUserRepository userRepo, RoleManager<IdentityRole> roleManager, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, TokenService tokenService)
        {
            _userRepo = userRepo;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        public async Task<bool> CheckEmailAsync(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email);
        }
        public async Task<UserResponse> CreateUserAsync(UserRequest userRequest)
        {
            var entity = UserFactory.CreateUserEntity();

            entity.Email = userRequest.Email;
            entity.FirstName = userRequest.FirstName;
            entity.LastName = userRequest.LastName;
            entity.PhoneNumber = userRequest.PhoneNumber;
            entity.UserName = userRequest.Email;
            entity.Issuer = userRequest.Issuer;

            var result = await _userManager.Users.AnyAsync();
            if (!result)
            {
                try
                {
                    entity.Issuer = "MANERO";
                    await _roleManager.CreateAsync(IdentityRoleFactory.CreateRole("User"));
                    await _roleManager.CreateAsync(IdentityRoleFactory.CreateRole("Admin"));
                    await _userManager.CreateAsync(entity, userRequest.Password);
                    await _userManager.AddToRoleAsync(entity, "Admin");
                    return UserFactory.CreateUserResponse(_tokenService.CreateToken(entity, "Admin"));
                }
                catch { return UserFactory.CreateUserResponse("Error while saving to database", userRequest); }
            } else
            {
                try
                {
                    var saveResult = await _userManager.CreateAsync(entity, userRequest.Password);
                    if (saveResult.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(entity, "User");
                        return UserFactory.CreateUserResponse(_tokenService.CreateToken(entity, "User"));
                    }
                    else
                    { return UserFactory.CreateUserResponse("Error while saveing", userRequest); }
                }
                catch { return UserFactory.CreateUserResponse("Something went wrong", userRequest); }
            }
        }
        // Kontrollera Roll
        public async Task<UserResponse> LogInAsync(LogInReq req)
        {
            try
            {
                var entity = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == req.Email);
                if (entity!.Issuer != "MANERO")
                    return UserFactory.CreateUserResponse($"You tried signing in with a different authentication method than the one you used during signup. Please try again using your {entity.Issuer} authentication account.", true);
                if (entity != null!)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(entity, req.Password, false, false);
                    if (signInResult.Succeeded)
                    {
                        var list = await _userManager.GetRolesAsync(entity);
                        return UserFactory.CreateUserResponse(_tokenService.CreateToken(entity, list[0]));
                    }
                    else { return UserFactory.CreateUserResponse("Error while signing in", true); }
                }

            }
            catch { return UserFactory.CreateUserResponse("Something went wrong", true); }
            return UserFactory.CreateUserResponse("Something went very wrong", true);
        }

        public async Task<UserResponse> CreateSocialAsync(UserRequest userRequest)
        {
            try
            {
                if (!await CheckEmailAsync(userRequest.Email)) //Om den inte finns i DB skapa
                {
                    userRequest.Password = "P" + Guid.NewGuid().ToString();
                    return await CreateUserAsync(userRequest);
                }
                else { return UserFactory.CreateUserResponse("An account alredy exists on this email -> go to forgott password", true); }

            }
            catch { return UserFactory.CreateUserResponse("Error while creating", true); }
        }
        public async Task<UserResponse> LogInExternalAsync(LogInExternalRequest request)
        {

            var entity = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if(entity == null)
            {
                return UserFactory.CreateUserResponse("You have no account", true);
            }
            try
            {
                if (entity!.Issuer == request.Issuer) 
                {
                    return UserFactory.CreateUserResponse(_tokenService.CreateToken(await _userManager.Users.FirstOrDefaultAsync(x => x.Email == request.Email), "User"));
                }
            else 
                {

                    return UserFactory.CreateUserResponse($"You tried signing in with a different authentication method than the one you used during signup. Please try again using your {entity.Issuer} authentication account.",true);
                }
            }
            catch { return UserFactory.CreateUserResponse("Something went wrong while login", true); }
        }
    }
}
