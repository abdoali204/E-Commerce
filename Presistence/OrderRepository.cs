using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core;
using E_Commerce.Core.Models;

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
            return await context.Orders.FindAsync(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return context.Orders;
        }
        public void RemoveOrder(Order order)
        {
            context.Orders.Remove(order);
        }
    }
}