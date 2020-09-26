using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace E_Commerce.Core.Models
{
    public class Basket
    {
        public int BasketId { get; set; }
        public ICollection<OrderDetails> BasketItems { get; set; }
        public Basket()
        {
            BasketItems = new Collection<OrderDetails>();
        }
    }
}