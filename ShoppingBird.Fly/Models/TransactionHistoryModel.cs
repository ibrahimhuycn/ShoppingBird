using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.Models
{
    public class TransactionHistoryModel
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int StoreId { get; set; }
        public string Store { get; set; }
        public int InvoiceDetailsId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal AdjustAmount { get; set; }
        public decimal Total { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
