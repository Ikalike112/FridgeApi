using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = Environment.GetEnvironmentVariable("adminEmail", EnvironmentVariableTarget.User) ?? "";
            string password = Environment.GetEnvironmentVariable("password", EnvironmentVariableTarget.User) ?? "";
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
        }
    }
}
