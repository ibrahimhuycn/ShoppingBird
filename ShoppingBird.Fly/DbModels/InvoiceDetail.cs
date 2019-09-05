using System;

namespace ShoppingBird.Fly.DbModels
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Tax { get; set; }
    }
}
