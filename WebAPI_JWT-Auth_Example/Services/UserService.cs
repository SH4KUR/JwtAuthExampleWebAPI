using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebAPI_JWT_Auth_Example.Helpers;
using WebAPI_JWT_Auth_Example.Services.Interfaces;

namespace WebAPI_JWT_Auth_Example.Services
{
    public class UserService : IUserService
    {
        private IOptions<AppSettings> _options;

        public UserService(IOptions<AppSettings> options)
        {
            _options = options;
        }
    }
}
