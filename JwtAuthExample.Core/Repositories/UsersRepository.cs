using System.Linq;
using System.Threading.Tasks;
using JwtAuthExample.Core.Entities;
using JwtAuthExample.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace JwtAuthExample.Core.Repositories
{
    public class UsersRepository<T> : IUsersRepository<T> where T : IdentityUser
    {
        private readonly UserManager<T> _manager;

        protected UsersRepository(UserManager<T> manager)
        {
            _manager = manager;
        }

        public async Task<T> GetByIdAsync(string id) => await _manager.FindByIdAsync(id);
        
        public async Task<T> GetByUserNameAsync(string userName) => await _manager.FindByNameAsync(userName);

        public IQueryable<T> GetAllAsync() => _manager.Users;

        public async Task<IdentityResult> CreateUser(T newUser, string password) => await _manager.CreateAsync(newUser, password);

        public async Task<IdentityResult> UpdateUser(T user) => await _manager.UpdateAsync(user);

        public async Task<IdentityResult> DeleteUser(T user) => await _manager.DeleteAsync(user);
    }
}