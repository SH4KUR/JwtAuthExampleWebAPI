using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using WebAPI_JWT_Auth_Example.Entities;
using WebAPI_JWT_Auth_Example.Models;

namespace WebAPI_JWT_Auth_Example.Data
{
    public static class ApplicationContextSeed
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var applicationContext = serviceProvider.GetService<ApplicationContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            try
            {
                if (!applicationContext.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole("admin"));
                    await roleManager.CreateAsync(new IdentityRole("user"));
                }

                if (!applicationContext.Users.Any())
                {
                    // create default user
                    var user = new ApplicationUser { UserName = "SingleBoy", Email = "boy.one@gmail.com" };
                    await userManager.CreateAsync(user, "S1ngle_Boy");
                    user = await userManager.FindByEmailAsync(user.Email);
                    await userManager.AddToRoleAsync(user, "user");
                    
                    // create default admin
                    var admin = new ApplicationUser { UserName = "SecondHand", Email = "2ndhand@gmail.com" };
                    await userManager.CreateAsync(admin, "For_Life19");
                    admin = await userManager.FindByEmailAsync(admin.Email);
                    await userManager.AddToRoleAsync(admin, "admin");
                }

                if (!applicationContext.Items.Any())
                {
                    // create default items
                    await applicationContext.Items.AddRangeAsync(GetItemsSeed());
                    await applicationContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                //TODO: add logger end exceptions
            }
        }

        private static IEnumerable<Item> GetItemsSeed()
        {
            return new List<Item>
            {
                new Item { ItemId = 1, Name = "Item1", Price = 100.25 },
                new Item { ItemId = 2, Name = "Item2", Price = 70.50 },
                new Item { ItemId = 3, Name = "Item3", Price = 63.99 },
                new Item { ItemId = 4, Name = "Item4", Price = 120.50 },
                new Item { ItemId = 5, Name = "Item5", Price = 47.69 }
            };
        }
    }
}
