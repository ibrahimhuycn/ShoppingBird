using ShoppingBird.Fly.Models;
using System;


namespace ShoppingBird.Fly.Interfaces
{
    public interface IInvoiceIO
    {
        IStaticInvoiceData LoadStaticData();
        int SaveInvoice(NewInvoice e);
    }
}
