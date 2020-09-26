using System.Threading.Tasks;
using E_Commerce.Core;

namespace E_Commerce.Presistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
           await context.SaveChangesAsync();
        }
    }
}