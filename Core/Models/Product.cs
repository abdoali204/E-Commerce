using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace E_Commerce.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public float Rating {get;set;}
        public int CategoryId {get;set;}
    
        public bool InStock {get;set;}
        public int MaterialId {get;set;}
        public Material Material {get;set;}
        public ProductCategory Category {get;set;}
        public ICollection<Photo> Photos {get;set;}
        public Product()
        {
            Photos = new Collection<Photo>();
        }
    }
}