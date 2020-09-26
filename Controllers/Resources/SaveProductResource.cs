using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace E_Commerce.Controllers.Resources
{
    public class SaveProductResource
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public float Price { get; set; }
        public float Rating {get;set;}
        public string Description { get; set; }
        public int CategoryId {get;set;}
        public bool InStock {get;set;}
        public int MaterialId {get;set;}
    }
}