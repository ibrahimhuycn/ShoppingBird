using ShoppingBird.Fly.Models;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IInvoiceIO
    {
        Task<int> SaveInvoiceAsync(NewInvoiceModel e);
    }
}
