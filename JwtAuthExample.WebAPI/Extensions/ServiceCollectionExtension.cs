﻿using JwtAuthExample.Core.Services;
using JwtAuthExample.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JwtAuthExample.WebAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(ITokenService), typeof(TokenService));
            serviceCollection.AddScoped(typeof(IUserService), typeof(UserService));
            serviceCollection.AddScoped(typeof(IItemService), typeof(ItemService));
        }
    }
}
