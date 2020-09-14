using System.Linq;
using System.Threading.Tasks;
using JwtAuthExample.Core.Data;
using JwtAuthExample.Core.Entities;
using JwtAuthExample.Core.Repositories;
using JwtAuthExample.Core.Services.Interfaces;

namespace JwtAuthExample.Core.Services
{
    public class ItemService : EfRepository<Item>, IItemService
    {
        public ItemService(ApplicationContext context) : base(context)
        {
        }

        public async Task<double> SumAllItemsPrices()
        {
            var items = await ListAllAsync();
            return items.Sum(x => x.Price);
        }
    }
}
