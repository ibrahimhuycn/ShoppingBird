using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.Models
{
    public class SearchResultsAllPriceDataForItemModel
    {
        public String Barcode { get; set; }
        public String StoreName { get; set; }
        public Decimal RetailPrice { get; set; }
    }
}
