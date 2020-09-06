using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAPI_JWT_Auth_Example.Helpers;
using WebAPI_JWT_Auth_Example.Services.Interfaces;

namespace WebAPI_JWT_Auth_Example.Services
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
