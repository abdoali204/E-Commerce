using System.Collections.Generic;

namespace E_Commerce.Controllers.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public float Rating {get;set;}
        public bool InStock {get;set;}
        public KeyValuePairResource ProductMaterial {get;set;}
        public KeyValuePairResource ProductCategory {get;set;}
        public IEnumerable<KeyValuePairResource> Photos {get;set;}
    }
}