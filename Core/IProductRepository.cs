using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core.Models;

namespace E_Commerce.Core
{
    public interface IProductRepository
    {
        IEnumerable<ProductCategory> GetCategories();
        Task<QueryResult<Product>> GetProducts(ProductQuery queryObject);
        Task<Product> GetProduct(int id);
        void Add(Product product);
        void Remove(Product product);
            
    }
}