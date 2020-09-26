using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core.Models;

namespace E_Commerce.Core
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Task<Order> GetOrderAsync(int id);
        void AddOrder(Order order);
        void RemoveOrder(Order order);

    }
}