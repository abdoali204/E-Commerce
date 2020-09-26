using System;

namespace E_Commerce.Controllers.Resources
{
    public class SavePaymentResource
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
    }
}