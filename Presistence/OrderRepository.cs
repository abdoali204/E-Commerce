using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Presistence
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await context.Orders.Include(o => o.Shipping).ThenInclude( s => s.Address)
            .Include(o => o.Basket.BasketItems).ThenInclude(bi => bi.Product).SingleOrDefaultAsync(o => o.Id == id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return context.Orders.Include(o => o.Shipping).ThenInclude(s => s.Address)
            .Include(o => o.Basket.BasketItems).ThenInclude(bi => bi.Product);
        }
        public void RemoveOrder(Order order)
        {
            context.Orders.Remove(order);
        }
        
        public IEnumerable<Order> GetOrdersByUserId(string UserSessionId)
        {
            return context.Orders.Include(o => o.Shipping).ThenInclude(s => s.Address)
                    .Include(o => o.Basket.BasketItems).ThenInclude(bi => bi.Product)
                    .Where( o => o.UserSessionId ==  UserSessionId);
        }
    }
}