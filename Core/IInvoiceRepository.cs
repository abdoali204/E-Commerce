using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core.Models;

namespace E_Commerce.Core
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetInvoices();
        Task<Invoice> GetInvoiceAsync(int id);
        void AddInvoice(Invoice invoice);
        void RemoveInvoice(Invoice invoice);
    }
}