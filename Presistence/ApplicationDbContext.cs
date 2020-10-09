
using E_Commerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Presistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Photo> Photos {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Material> Materials {get;set;}
        public DbSet<Basket> Baskets {get;set;}
        public DbSet<OrderDetails> OrderDetails {get;set;}
        public DbSet<Order> Orders {get;set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}