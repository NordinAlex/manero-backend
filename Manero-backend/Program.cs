using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Manero_backend.Context;
using Manero_backend.Factories.CartRelatedFactories;
using Manero_backend.Interfaces.Addresses.Repository;
using Manero_backend.Interfaces.Addresses.Service;
using Manero_backend.Interfaces.Cart;
using Manero_backend.Interfaces.Order;
using Manero_backend.Interfaces.OrderLine;
using Manero_backend.Interfaces.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Interfaces.Product.Services;
using Manero_backend.Interfaces.Users.Repositories;
using Manero_backend.Interfaces.Users.Service;
using Manero_backend.Models.UserEntities;
using Manero_backend.Repository;
using Manero_backend.Repository.CartRepository;
using Manero_backend.Services;
using Manero_backend.Services.CartRelatedServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// User SQL Server
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Manero")));


// Product SQL Server
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductSql")));

// Product services
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<TokenService>(); //Interfaces kommer sen PB JBB // Vill vi ha denna som Scoped?(PB)
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ISizeRepository, SizeRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITypeRepository, TypeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductItemRepository, ProductItemRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderLineRepository, OrderLineRepository>();
builder.Services.AddScoped<IOrderLineService, OrderLineService>();
builder.Services.AddScoped<IAuthService, AuthServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserServices>();

builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IShoppingCartServiceFactory, ShoppingCartServiceFactory>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();

builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<IdentityContext>();

// Authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x => 
    {
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["TokenService:Issuer"]!,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["TokenService:Audience"]!,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenService:Secret"]!))
        };
        x.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var securityToken = context.SecurityToken;
                if (securityToken != null)
                {
                    if (securityToken.Issuer != "MANERO")
                        context.Fail("Wrong Issuer");
                    if (securityToken.ValidTo < DateTimeOffset.UtcNow)
                        context.Fail("Tokex expired");

                }

                if (string.IsNullOrEmpty(context.Principal?.Identity?.Name))
                
                { context.Fail("Unauthorized"); }
                //Cheacka flera saker, nu kollar vi Name(email), vi kan kolla mer värden

                return Task.CompletedTask;
            }
        };
    });



var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
