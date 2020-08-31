using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_JWT_Auth_Example.Models;

namespace WebAPI_JWT_Auth_Example.Data
{
    public static class UsersDbContextSeed
    {
        public static async Task SeedAsync(UsersDbContext usersDbContext)
        {
            try
            {
                if (!usersDbContext.ApplicationUsers.Any())
                {
                    await usersDbContext.ApplicationUsers.AddRangeAsync(GetUsersSeed());
                    await usersDbContext.SaveChangesAsync();
                }

                if (!usersDbContext.Role.Any())
                {
                    await usersDbContext.Role.AddRangeAsync(GetRolesSeed());
                    await usersDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                //TODO: add logger end exceptions
            }
        }

        private static IEnumerable<ApplicationUser> GetUsersSeed()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser { UserId = 1, UserName = "UsOneEr", Email = "userlogin@gmail.com", Password = "qwerty123", RoleId = 1 },
                new ApplicationUser { UserId = 2, UserName = "SecondHand", Email = "2ndhand@gmail.com", Password = "pass-29", RoleId = 2 },
                new ApplicationUser { UserId = 3, UserName = "Triple H", Email = "hhh@gmail.com", Password = "h1n1+b2e2", RoleId = 2 },
                new ApplicationUser { UserId = 4, UserName = "4Life", Email = "life4@gmail.com", Password = "for_life19", RoleId = 2 }
            };
        }

        private static IEnumerable<Role> GetRolesSeed()
        {
            return new List<Role>
            {
                new Role { RoleId = 1, Name = "admin"},
                new Role { RoleId = 2, Name = "user"}
            };
        }
    }
}
