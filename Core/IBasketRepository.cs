using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core.Models;

namespace E_Commerce.Core
{
    public interface IBasketRepository
    {
        void AddBasket(Basket Basket);
        void DeleteBasket(Basket Basket);
        IEnumerable<Basket> GetBaskets();
        Task<Basket> GetBasketAsync(int id);
        float CalcBasketCost(Basket basket);
    }
}