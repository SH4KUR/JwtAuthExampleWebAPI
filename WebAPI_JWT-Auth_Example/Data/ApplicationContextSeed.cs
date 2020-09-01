using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_JWT_Auth_Example.Models;

namespace WebAPI_JWT_Auth_Example.Data
{
    public static class ApplicationContextSeed
    {
        public static async Task SeedAsync(ApplicationContext applicationContext)
        {
            try
            {
                if (!applicationContext.User.Any())
                {
                    await applicationContext.User.AddRangeAsync(GetUsersSeed());
                    await applicationContext.SaveChangesAsync();
                }

                if (!applicationContext.UserRole.Any())
                {
                    await applicationContext.UserRole.AddRangeAsync(GetRolesSeed());
                    await applicationContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                //TODO: add logger end exceptions
            }
        }

        private static IEnumerable<User> GetUsersSeed()
        {
            return new List<User>
            {
                new User { UserId = 1, UserName = "UsOneEr", Email = "userlogin@gmail.com", Password = "qwerty123", UserRoleId = 1 },
                new User { UserId = 2, UserName = "SecondHand", Email = "2ndhand@gmail.com", Password = "pass-29", UserRoleId = 2 },
                new User { UserId = 3, UserName = "Triple H", Email = "hhh@gmail.com", Password = "h1n1+b2e2", UserRoleId = 2 },
                new User { UserId = 4, UserName = "SingleBoy", Email = "boy.ones@gmail.com", Password = "s1ngle-boy", UserRoleId = 1 },
                new User { UserId = 5, UserName = "4Life", Email = "life4@gmail.com", Password = "for_life19", UserRoleId = 2 }
            };
        }

        private static IEnumerable<UserRole> GetRolesSeed()
        {
            return new List<UserRole>
            {
                new UserRole { UserRoleId = 1, Name = "admin"},
                new UserRole { UserRoleId = 2, Name = "user"}
            };
        }
    }
}
