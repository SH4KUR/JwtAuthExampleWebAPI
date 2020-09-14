using System.Threading.Tasks;
using JwtAuthExample.Core.Repositories;
using JwtAuthExample.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace JwtAuthExample.Core.Services.Interfaces
{
    public interface IUserService
    {
        public Task<SignInResult> IsSignIn(string userName, string password, bool isPersistent = false,
            bool lockoutOnFailure = false);
    }
}
