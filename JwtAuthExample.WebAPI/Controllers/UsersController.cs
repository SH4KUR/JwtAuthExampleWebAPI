using System.Threading.Tasks;
using JwtAuthExample.Core.Data;
using JwtAuthExample.Core.Entities;
using JwtAuthExample.Core.Models;
using JwtAuthExample.Core.Services.Interfaces;
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
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UsersController(IUserService userService, ITokenService tokenService)
        {  
            _userService = userService;
            _tokenService = tokenService;
        }

        // POST: api/users/login
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var sign = await _userService.IsSignIn(loginModel.UserName, loginModel.Password);
            var user = await _userService.GetByUserNameAsync(loginModel.UserName);

            if (!sign.Succeeded) 
                return Unauthorized();
            
            var token = await _tokenService.GetTokenAsync(user);
            return Ok(new AuthenticateResponse { UserName = user.UserName, Email = user.Email, Token = token });
        }
    }
}
