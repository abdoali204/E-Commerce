namespace E_Commerce.Controllers.Resources
{
    public class AddressResource
    {
        public int Id { get; set; }  
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

    }
}