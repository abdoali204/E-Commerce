using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core;
using E_Commerce.Core.Models;

namespace E_Commerce.Presistence
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
        }

        public async Task<Invoice> GetInvoiceAsync(int id)
        {
            return await context.Invoices.FindAsync(id);
        }

        public IEnumerable<Invoice> GetInvoices()
        {
            return context.Invoices;
        }

        public void RemoveInvoice(Invoice invoice)
        {
            context.Invoices.Remove(invoice);
        }
    }
}