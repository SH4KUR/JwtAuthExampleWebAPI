using Microsoft.Extensions.DependencyInjection;
using WebAPI_JWT_Auth_Example.Services;
using WebAPI_JWT_Auth_Example.Services.Interfaces;

namespace WebAPI_JWT_Auth_Example.Configuration
{
    public static class ConfigureServices
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(ITokenService), typeof(TokenService));
            serviceCollection.AddScoped(typeof(IUserService), typeof(UserService));
            serviceCollection.AddScoped(typeof(IItemService), typeof(ItemService));
        }
    }
}
