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
        public decimal AdjustAmount { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        
    }
}
