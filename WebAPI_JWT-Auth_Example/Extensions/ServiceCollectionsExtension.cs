using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebAPI_JWT_Auth_Example.Services;
using WebAPI_JWT_Auth_Example.Services.Interfaces;

namespace WebAPI_JWT_Auth_Example.Extensions
{
    public static class ServiceCollectionsExtension
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(ITokenService), typeof(TokenService));
            serviceCollection.AddScoped(typeof(IUserService), typeof(UserService));
            serviceCollection.AddScoped(typeof(IItemsService), typeof(ItemsService));
        }
    }
}
