namespace E_Commerce.Controllers.Resources
{
    public class SaveShippingResource
    {
        public int Id { get; set; } 
        public string ShippingMethod {get;set;}
        public float ShippingCharge {get;set;}
        public SaveAddressResource Address { get; set; }
    }
}