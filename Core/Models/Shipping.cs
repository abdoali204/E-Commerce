namespace E_Commerce.Core.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public string ShippingMethod { get; set; }     
        public float ShippingCharge { get; set; }     
        public int AddressId { get; set; }
        public Address Address {get;set;}
        
    }
}