using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.DbModels
{
    public class PriceList
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Barcode { get; set; }
        public int TaxId { get; set; }
        public int StoreId { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal UnitId { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
