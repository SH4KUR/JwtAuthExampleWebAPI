using System.Linq;
using System.Threading.Tasks;
using JwtAuthExample.Core.Entities;
using JwtAuthExample.Core.Repositories;
using JwtAuthExample.Core.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace JwtAuthExample.Core.Services
{
    public class UserService : UsersRepository, IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserService(UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> signInManager) : base(manager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> IsSignIn(string userName, string password, bool isPersistent = false, bool lockoutOnFailure = false)
        {
            var user = await GetByUserNameAsync(userName);
            return await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        }
    }
}
