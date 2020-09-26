using System;

namespace E_Commerce.Core.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
    }
}