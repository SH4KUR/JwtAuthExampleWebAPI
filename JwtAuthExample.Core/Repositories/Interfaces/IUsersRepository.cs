using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthExample.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace JwtAuthExample.Core.Repositories.Interfaces
{
    public interface IUsersRepository<T> where T: IdentityUser
    {
        Task<T> GetByIdAsync(string id);
        Task<T> GetByUserNameAsync(string userName);
        IQueryable<ApplicationUser> GetAllAsync();
        Task<IdentityResult> CreateUser(T newUser, string password);
        Task<IdentityResult> UpdateUser(T user);
        Task<IdentityResult> DeleteUser(T user);
    }
}