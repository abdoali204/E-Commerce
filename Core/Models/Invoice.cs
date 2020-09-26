using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace E_Commerce.Core.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Invoice()
        {
            Orders = new Collection<Order>();
        }
    }
}