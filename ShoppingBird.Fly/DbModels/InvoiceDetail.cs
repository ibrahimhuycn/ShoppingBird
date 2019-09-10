using System;

namespace ShoppingBird.Fly.DbModels
{
    public class InvoiceDetail
    {
      public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Tax { get; set; }
    }
}
