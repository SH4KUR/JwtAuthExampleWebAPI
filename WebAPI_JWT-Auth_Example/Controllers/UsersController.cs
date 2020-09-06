using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebAPI_JWT_Auth_Example.Data;
using WebAPI_JWT_Auth_Example.Entities;
using WebAPI_JWT_Auth_Example.Helpers;
using WebAPI_JWT_Auth_Example.Models;
using WebAPI_JWT_Auth_Example.Services;
using WebAPI_JWT_Auth_Example.Services.Interfaces;

namespace WebAPI_JWT_Auth_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;   //TODO: Refactoring
        private AppSettings _appSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UsersController(ITokenService tokenService, ApplicationContext context, IOptions<AppSettings> options, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {  
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _appSettings = options.Value;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            var sign = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

            if (sign.Succeeded)
            {
                var token = await _tokenService.GetTokenAsync(user);
                return Ok(new AuthenticateResponse { UserName = user.UserName, Email = user.Email, Token = token });
            }

            return Unauthorized();
        }
    }
}
