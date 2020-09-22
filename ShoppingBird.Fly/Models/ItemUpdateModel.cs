using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;

namespace ShoppingBird.Fly.Models
{
    public class ItemUpdateModel
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        public int StoreId { get; set; }
        public decimal RetailPrice { get; set; }
        public int TaxId { get; set; }
        public int UnitId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
