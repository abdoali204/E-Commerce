using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace E_Commerce.Controllers.Resources
{
    public class SaveOrderResource
    {
       public int Id { get; set; }
       public int TotalAmount { get; set; }
       public string State {get;set;}
       public int PaymentId { get; set; }
       public int? InvoiceId {get;set;}
       public int ShippingId { get; set; }  
       public SaveBasketResource OrderDetails { get; set; }
    }
}