using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebAPI_JWT_Auth_Example.Data;
using WebAPI_JWT_Auth_Example.Helpers;
using WebAPI_JWT_Auth_Example.Models;

namespace WebAPI_JWT_Auth_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private AppSettings _appSettings;

        public UsersController(ApplicationContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _appSettings = options.Value;
        }

    }
}
