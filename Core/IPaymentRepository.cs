using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core.Models;

namespace E_Commerce.Core
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetPayments();
        Task<Payment> GetPaymentAsync(int id);
        void AddPayment(Payment payment);
        void RemovePayment(Payment Payment);
    }
}