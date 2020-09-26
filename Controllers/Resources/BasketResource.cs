using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace E_Commerce.Controllers.Resources
{
    public class BasketResource
    {
        public int BasketId { get; set; }
        public IEnumerable<OrderDetailsResource> BasketItems { get; set; }   
        public BasketResource()
        {
            BasketItems = new Collection<OrderDetailsResource>();
        }
    }
}