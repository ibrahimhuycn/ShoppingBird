using ShoppingBird.Fly.DbModels;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Models
{
    public class NewInvoice
    {
        public Invoice Invoice { get; set; }
        public IList<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
