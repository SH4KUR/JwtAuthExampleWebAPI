using System.Threading.Tasks;
using WebAPI_JWT_Auth_Example.Models;

namespace WebAPI_JWT_Auth_Example.Services.Interfaces
{
    interface ITokenService
    {
        Task<string> GetTokenAsync(ApplicationUser user);  
    }
}
