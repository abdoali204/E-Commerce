using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core;
using E_Commerce.Core.Models;

namespace E_Commerce.Presistence
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly ApplicationDbContext context;

        public ShippingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddShipping(Shipping shipping)
        {
            context.Shippings.Add(shipping);
        }

        public async Task<Shipping> GetShippingAsync(int id)
        {
            return await context.Shippings.FindAsync(id);
        }

        public IEnumerable<Shipping> GetShippings()
        {
            return context.Shippings;
        }
        public void RemoveShipping(Shipping shipping)
        {
            context.Shippings.Remove(shipping);
        }
    }
}