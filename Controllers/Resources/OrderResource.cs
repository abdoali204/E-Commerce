using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace E_Commerce.Controllers.Resources
{
    public class OrderResource
    {
       public int Id { get; set; }
       public DateTime Date { get; set; }
       public int TotalAmount { get; set; }
       public string State {get;set;}
       public InvoiceResource Invoice {get;set;}
       public PaymentResource Payment {get;set;}
       public ShippingResource Shipping {get;set;}      
       
       public ICollection<OrderDetailsResource> OrderDetails { get; set; }
       public OrderResource()
       {
           OrderDetails = new Collection<OrderDetailsResource>();
       }
    }
}