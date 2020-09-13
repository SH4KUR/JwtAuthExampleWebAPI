using System.Threading.Tasks;
using JwtAuthExample.Core.Entities;
using JwtAuthExample.Core.Models;
using JwtAuthExample.Core.Services.Interfaces;
using JwtAuthExample.Infrastructure.Data;
using JwtAuthExample.WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JwtAuthExample.WebAPI.Controllers
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
