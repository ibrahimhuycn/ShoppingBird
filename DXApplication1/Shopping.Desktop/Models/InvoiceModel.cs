using System;

namespace Shopping.Desktop.Models
{
    public class InvoiceModel
    {
        public int StoreId { get; set; }
        public string Number { get; set; }
        public decimal AdjustAmount { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
}
