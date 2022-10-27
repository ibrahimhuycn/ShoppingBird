using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IInvoiceIO
    {
        Task<List<TransactionHistoryModel>> GetTransactionHistoryAsync();
        Task<List<TransactionHistoryModel>> GetTransactionHistoryAsync(DateTime startDate, DateTime endDate);
        Task<int> SaveInvoiceAsync(NewInvoiceModel e);
    }
}
