using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Mobile.Models
{
    public class AddPriceForStoreArgs
    {
        public string Barcode { get; internal set; }
        public StoreModel CurrentStore { get; internal set; }
        public string Description { get; internal set; }
        public int ItemTaxId { get; internal set; }
        public int ItemCatId { get; internal set; }
        public int ItemSubCatId { get; internal set; }
        public int ItemUnitId { get; internal set; }
    }
}
