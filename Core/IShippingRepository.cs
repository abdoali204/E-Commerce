using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core.Models;

namespace E_Commerce.Core
{
    public interface IShippingRepository
    {
        IEnumerable<Shipping> GetShippings();
        Task<Shipping> GetShippingAsync(int id);
        void AddShipping(Shipping order);
        void RemoveShipping(Shipping order);
    }
}