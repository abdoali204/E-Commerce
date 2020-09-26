using System.Collections.Generic;

namespace E_Commerce.Controllers.Resources
{
    public class QueryResultResource<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items {get;set;}
    }
}