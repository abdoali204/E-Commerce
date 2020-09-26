using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace E_Commerce.Controllers.Resources
{
    public class SaveBasketResource
    {
        public int BasketId { get; set; }
        public IEnumerable<SaveOrderDetailsResource> BasketItems { get; set; }   
        public SaveBasketResource()
        {
            BasketItems = new Collection<SaveOrderDetailsResource>();
        }
    }
}