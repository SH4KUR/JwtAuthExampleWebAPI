using JwtAuthExample.Core.Entities;
using JwtAuthExample.Core.Repositories;
using JwtAuthExample.Core.Services.Interfaces;

namespace JwtAuthExample.Core.Services
{
    public class ItemService : EfRepository<Item>, IItemService
    {
    }
}
