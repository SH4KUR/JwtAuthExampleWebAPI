using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthExample.Core.Entities;
using JwtAuthExample.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace JwtAuthExample.Core.Repositories
{
    public class UsersRepository : IUsersRepository<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _manager;

        public UsersRepository(UserManager<ApplicationUser> manager)
        {
            _manager = manager;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id) => await _manager.FindByIdAsync(id);
        
        public async Task<ApplicationUser> GetByUserNameAsync(string userName) => await _manager.FindByNameAsync(userName);

        public IQueryable<ApplicationUser> GetAllAsync() => _manager.Users;

        public async Task<IdentityResult> CreateUser(ApplicationUser newUser, string password) => await _manager.CreateAsync(newUser, password);

        public async Task<IdentityResult> UpdateUser(ApplicationUser user) => await _manager.UpdateAsync(user);

        public async Task<IdentityResult> DeleteUser(ApplicationUser user) => await _manager.DeleteAsync(user);
    }
}