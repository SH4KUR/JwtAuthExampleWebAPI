using JwtAuthExample.WebAPI.Helpers;
using JwtAuthExample.WebAPI.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace JwtAuthExample.WebAPI.Services
{
    public class UserService : IUserService
    {
        private AppSettings _options;

        public UserService(IOptions<AppSettings> options)
        {
            _options = options.Value;
        }
    }
}
