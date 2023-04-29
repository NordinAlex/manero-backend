using Manero_backend.Context;
using Manero_backend.Models.UserEntities;
using Manero_backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UserService>();
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Manero")));
builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
    x.Password.RequiredLength = 6;
    x.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<IdentityContext>();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
});


// Product services
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductSql")));

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
