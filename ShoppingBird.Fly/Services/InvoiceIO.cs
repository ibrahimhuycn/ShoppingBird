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
        public async Task SaveInvoiceAsync(NewInvoiceModel e)
        {
            var storedProcedure = "[dbo].[usp_InsertInvoiceAndInvoiceDetails]";
            var parameters = new 
            {
                StoreId = e.Invoice.StoreId,
                Number = e.Invoice.Number,
                SubTotal = e.Invoice.SubTotal,
                AdjustAmount = e.Invoice.AdjustAmount,
                Total = e.Invoice.Total,
                UserId = e.Invoice.UserId,
                Date = e.Invoice.InvoiceDate,
                InvoiceDetails = _dataAccessBase.GetInvoiceDetailsUDT(e.CartItems)
            };

            _ = await _dataAccessBase.SelectInsertOrUpdateAsync<dynamic, dynamic>(storedProcedure, parameters);
        }
    }
}
 