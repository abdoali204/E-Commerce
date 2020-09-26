namespace E_Commerce.Controllers.Resources
{
    public class ShippingResource
    {
        public int Id { get; set; }
        public string ShippingMethod { get; set; }     
        public float ShippingCharge { get; set; }     
        public AddressResource Address {get;set;}
    }
}