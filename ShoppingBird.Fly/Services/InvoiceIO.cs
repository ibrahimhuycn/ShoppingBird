using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Services
{
    public class InvoiceIO : IInvoiceIO
    {
        private readonly IDataAccessBase _dataAccessBase;

        public InvoiceIO(IDataAccessBase dataAccessBase)
        {
            _dataAccessBase = dataAccessBase;
        }
        public async Task<int> SaveInvoiceAsync(NewInvoiceModel e)
        {
            var storedProcedure = "[dbo].[usp_InsertInvoiceAndInvoiceDetails]";
            var parameters = new 
            {
                StoreId = e.Invoice.StoreId,
                Number = e.Invoice.Number,
                AdjustAmount = e.Invoice.AdjustAmount,
                Total = e.Invoice.Total,
                UserId = e.Invoice.UserId,
                Date = e.Invoice.InvoiceDate,
                InvoiceDetails = _dataAccessBase.GetInvoiceDetailsUDT(e.CartItems)
            };

            var insertedInvoiceId = await _dataAccessBase.SelectInsertOrUpdateAsync<int, dynamic>(storedProcedure, parameters);
            return insertedInvoiceId;
        }

        public async Task<List<TransactionHistoryModel>> GetTransactionHistoryAsync()
        {
            var storedProcedure = "[dbo].[usp_GetTransactionHistory]";
            var data = await _dataAccessBase.LoadDataAsync<TransactionHistoryModel>(storedProcedure);
            return data;
        }
        public async Task<List<TransactionHistoryModel>> GetTransactionHistoryAsync(DateTime startDate, DateTime endDate)
        {
            var storedProcedure = "[dbo].[usp_GetTransactionHistoryForPeriod]";
            var parameters = new
            {
                StartDate = $"{startDate:yyyy-MM-dd} 00:00:00.000",
                EndDate = $"{endDate:yyyy-MM-dd} 23:59:59.999",
            };
            var data = await _dataAccessBase.LoadDataWithParameterAsync<TransactionHistoryModel, dynamic>
                (storedProcedure, parameters);
            return data;
        }
    }
}
 