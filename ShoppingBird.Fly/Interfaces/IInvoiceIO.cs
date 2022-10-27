using ShoppingBird.Fly.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IInvoiceIO
    {
        Task<List<TransactionHistoryModel>> GetTransactionHistoryAsync();
        Task<int> SaveInvoiceAsync(NewInvoiceModel e);
    }
}
