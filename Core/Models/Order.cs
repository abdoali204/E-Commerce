using System;
using System.Collections.Generic;

namespace E_Commerce.Core.Models
{  
   public class Order
   {
       public int Id { get; set; }
       public DateTime Date { get; set; }
       public int TotalAmount { get; set; }
       public string State {get;set;}
       public int PaymentId { get; set; }
       public int? InvoiceId {get;set;}
       public int ShippingId { get; set; }   
       public int BasketId {get;set;}
       public Invoice Invoice {get;set;}
       public Payment Payment {get;set;}
       public Shipping Shipping {get;set;} 
       public Basket Basket { get; set; }
   } 
}