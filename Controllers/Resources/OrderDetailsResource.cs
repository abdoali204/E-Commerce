namespace E_Commerce.Controllers.Resources
{
    public class OrderDetailsResource
    {
        
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price {get;set;}
        public int Quantity { get; set; }
        public string FileName {get;set;}
    }
}