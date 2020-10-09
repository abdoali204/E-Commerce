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
       public int? InvoiceId {get;set;}
       public int ShippingId { get; set; }  
       public string UserSessionId {get;set;}
       public SaveBasketResource Basket { get; set; }
    }
}