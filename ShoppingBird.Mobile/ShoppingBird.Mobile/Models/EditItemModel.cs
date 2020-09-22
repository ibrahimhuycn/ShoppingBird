using ShoppingBird.Fly.Models;
using System;

namespace ShoppingBird.Mobile.Models
{
    public class EditItemArgs : AddPriceForStoreArgs
    {
        public double RetailPrice { get; set; }

        internal EditItemArgs SetUpdatedData(ItemUpdateModel e)
        {
            this.Description = e.Description;
            this.RetailPrice = double.Parse(e.RetailPrice.ToString());
            this.ItemTaxId = e.TaxId;
            return this;
        }
    }
}
