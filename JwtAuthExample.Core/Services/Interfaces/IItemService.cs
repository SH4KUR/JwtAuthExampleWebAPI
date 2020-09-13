using JwtAuthExample.Core.Entities;
using JwtAuthExample.Core.Repositories;
using JwtAuthExample.Core.Repositories.Interfaces;

namespace JwtAuthExample.Core.Services.Interfaces
{
    public interface IItemService : IAsyncRepository<Item>
    {
    }
}
