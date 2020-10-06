using Autofac;
using JwtAuthExample.Core.Services;
using JwtAuthExample.Core.Services.Interfaces;

namespace JwtAuthExample.WebAPI.Extensions
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TokenService>().As<ITokenService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ItemService>().As<IItemService>();
        }
    }
}