using MedicalManagementSystem.Model.Auth;
using Microsoft.AspNetCore.Identity;

namespace MedicalManagementSystem.Data
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(
            IServiceProvider services,
            IConfiguration configuration)
        {
            var roleManager = services.GetRequiredService<RoleManager<Role>>();
            var userManager = services.GetRequiredService<UserManager<User>>();
            foreach (var roleName in AppRoles.All)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                    await roleManager.CreateAsync(new Role { Name = roleName });
            }
            var adminSection = configuration.GetSection("AdminUser");
            var adminEmail = adminSection["Email"];
            var adminPassword = adminSection["Password"];
            if (string.IsNullOrWhiteSpace(adminEmail) ||
                string.IsNullOrWhiteSpace(adminPassword))
                return;
            if (await userManager.FindByEmailAsync(adminEmail) != null)
                return;
            var adminRole = await roleManager.FindByNameAsync(AppRoles.Admin);
            var admin = new User
            {
                UserName = adminEmail,
                Email = adminEmail,
                FullName = adminSection["FullName"] ?? "System Admin",
                RoleId = adminRole!.Id,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(admin, adminPassword);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, AppRoles.Admin);
        }
    }
}
