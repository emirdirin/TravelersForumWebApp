using Homework1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PlaceDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PlacesDBConnection")));

builder.Services.AddDbContext<UserInfoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("UsersDBConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<UserInfoDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();


app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();