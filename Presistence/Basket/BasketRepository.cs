using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Presistence
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ApplicationDbContext context;

        public BasketRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddBasket(Basket Basket)
        {
            context.Baskets.Add(Basket);
        }

        public void DeleteBasket(Basket Basket)
        {
            context.Baskets.Remove(Basket);
        }

        public async Task<Basket> GetBasketAsync(int id)
        {
            return await context.Baskets.Include(b => b.BasketItems).ThenInclude(bi => bi.Product).SingleOrDefaultAsync(b => b.BasketId == id);
        }

        public IEnumerable<Basket> GetBaskets()
        {
            return context.Baskets.Include(b=> b.BasketItems.Select(bi => bi.Product));   
        }
    }
}