using System.Threading.Tasks;
using JwtAuthExample.Core.Entities;

namespace JwtAuthExample.WebAPI.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(ApplicationUser user);  
    }
}
