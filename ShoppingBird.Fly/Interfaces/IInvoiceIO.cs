using ShoppingBird.Fly.Models;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IInvoiceIO
    {
        Task SaveInvoiceAsync(NewInvoiceModel e);
    }
}
