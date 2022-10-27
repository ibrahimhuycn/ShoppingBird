using System;

namespace ShoppingBird.Fly.Models
{
    public class InvoiceModel
    {
        public int StoreId { get; set; }
        public int Number { get; set; }
        public decimal SubTotal { get; set; }
        public decimal AdjustAmount { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
}
