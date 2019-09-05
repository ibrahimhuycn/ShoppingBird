using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IStaticInvoiceData
    {
        IList<Store> MyProperty { get; set; }
        IObservable<Tax> TaxData { get; set; }
    }
}
