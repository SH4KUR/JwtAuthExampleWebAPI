using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPI_JWT_Auth_Example.Helpers;
using WebAPI_JWT_Auth_Example.Models;
using WebAPI_JWT_Auth_Example.Services.Interfaces;

namespace WebAPI_JWT_Auth_Example.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _options;

        public TokenService(UserManager<ApplicationUser> userManager, IOptions<AppSettings> options)
        {
            _userManager = userManager;
            _options = options.Value;
        }

        /// <summary>
        /// Generate token for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> GetTokenAsync(ApplicationUser user)
        {
            var key = Encoding.ASCII.GetBytes(_options.Key);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(_options.LifeTimeSec),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
