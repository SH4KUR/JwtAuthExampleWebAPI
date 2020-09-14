using System.Threading.Tasks;
using JwtAuthExample.Core.Entities;
using JwtAuthExample.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace JwtAuthExample.Core.Services.Interfaces
{
    public interface IUserService : IUsersRepository<ApplicationUser>
    {
        public Task<SignInResult> IsSignIn(string userName, string password, bool isPersistent = false,
            bool lockoutOnFailure = false);
    }
}
