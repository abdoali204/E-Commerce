using System.Threading.Tasks;

namespace E_Commerce.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}