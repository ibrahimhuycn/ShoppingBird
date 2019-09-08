using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.Models
{
    public class ItemSearchResultModel
    {
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal Rate { get; set; }
        public string ErrorMessage { get; set; } = null;
    }
}
