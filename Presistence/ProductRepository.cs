using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using E_Commerce.Extentions;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Presistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Product product)
        {
            context.Products.Add(product);
        }

        public IEnumerable<ProductCategory> GetCategories()
        {
            return context.ProductCategories;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await context.Products.Include(p=> p.Category).Include(p=> p.Material).SingleOrDefaultAsync( p=> p.Id == id);                         
        }
        public async Task<QueryResult<Product>> GetProducts(ProductQuery queryObject)
        {
            var result = new QueryResult<Product>();
            var columnsMap =new  Dictionary<string,Expression<Func<Product,object>>>
            {
                ["productName"] = p => p.Name,
                ["rating"] = p=> p.Rating,
                ["category"] = p=> p.Category.Name
            };
            var products =  context.Products
                        .Include(p=>p.Category)
                        .Include(p=>p.Material).AsQueryable();
            //filtering
            products = products.ApplyFiltering(queryObject);
            //ordering
            products = products.ApplyOrdering(queryObject,columnsMap);
            result.TotalItems = await products.CountAsync();
            //Paging
            products = products.Paging(queryObject);
            result.Items =await products.ToListAsync();
            return result;
                
        }

        public void Remove(Product product)
        {
            context.Products.Remove(product);
        }
    }
}