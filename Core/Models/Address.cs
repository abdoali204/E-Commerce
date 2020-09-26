using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Core.Models
{
    public class Address
    {
        public int Id { get; set; }  
        [Required(ErrorMessage = "Please enter the first address line")] 
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")] 
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")] 
        public string State { get; set; }

        public string Zip { get; set; }


        public ICollection<Shipping> Shippings {get;set;}

        public Address()
        {
            Shippings = new Collection<Shipping>();
        }
    }
}