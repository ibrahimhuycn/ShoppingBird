using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;


namespace ShoppingBird.Fly
{
    public class InvoiceIO : IInvoiceIO
    {
        
        public int SaveInvoice(NewInvoice e)
        {
            throw new NotImplementedException();
        }

        IStaticInvoiceData IInvoiceIO.LoadStaticData()
        {
            throw new NotImplementedException();
        }
    }
}
