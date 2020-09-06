using System.Threading.Tasks;
using WebAPI_JWT_Auth_Example.Entities;
using WebAPI_JWT_Auth_Example.Models;

namespace WebAPI_JWT_Auth_Example.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(ApplicationUser user);  
    }
}
