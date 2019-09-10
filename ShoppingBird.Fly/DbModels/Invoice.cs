using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.DbModels
{
    public class Invoice
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int Number { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public int Date { get; set; }
        public DateTime UserId { get; set; }
    }
}
