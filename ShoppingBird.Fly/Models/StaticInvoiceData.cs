using ShoppingBird.Fly.Interfaces;
using System;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Models
{

    public class StaticInvoiceData: IStaticInvoiceData
    {
        public IList<Store> MyProperty { get; set; }
        public IObservable<Tax> TaxData { get; set; }
    }
}
