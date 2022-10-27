using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = Environment.GetEnvironmentVariable("FridgeAdminEmail", EnvironmentVariableTarget.User) ?? "admin@example.com";
            string password = Environment.GetEnvironmentVariable("FridgePassword", EnvironmentVariableTarget.User) ?? "password";
            var admin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                LastLoginDate = DateTime.Now,
                RegistrationDate = DateTime.Now
            };
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Administrator");
                }
            }
            string userEmail = "user@example.com";
            string userPassword = "password";
            var user = new ApplicationUser
            {
                UserName = userEmail,
                Email = userEmail,
                LastLoginDate = DateTime.Now,
                RegistrationDate = DateTime.Now
            };
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Administrator");
                }
            }
        }
    }
}
