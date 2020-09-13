using System.Threading.Tasks;
using JwtAuthExample.Core.Entities;

namespace JwtAuthExample.Core.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(ApplicationUser user);  
    }
}
