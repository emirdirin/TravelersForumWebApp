using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Homework1.Models
{
    public static class SeedUser
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "AdminPassword123$";
        private const string regularUser = "User";
        private const string regularPassword = "UserPassword123$";
        private const string adminRole = "Admin";
        private const string userRole = "User";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserInfoDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserInfoDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager =
                app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            var roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }
            if (await roleManager.FindByNameAsync(userRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(userRole));
            }
        }
    }
}
