using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core;
using E_Commerce.Core.Models;

namespace E_Commerce.Presistence
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext context;

        public PaymentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddPayment(Payment Payment)
        {
            context.Payments.Add(Payment);
        }

        public async Task<Payment> GetPaymentAsync(int id)
        {
            return await context.Payments.FindAsync(id);
        }

        public IEnumerable<Payment> GetPayments()
        {
            return context.Payments;
        }

        public void RemovePayment(Payment Payment)
        {
            context.Payments.Remove(Payment);
        }
    }
}