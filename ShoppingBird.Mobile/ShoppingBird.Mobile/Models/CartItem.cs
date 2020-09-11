using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ShoppingBird.Mobile.Models
{
    public class CartItem
    {
        public CartItem()
        {
            this.TaxData = new List<TaxModel>();
        }
        public CartItem GetPartialInvoiceItem(Product product)
        {
            this.ItemId = product.Id;
            this.Barcode = product.Item.Split('|')[0].Trim();
            this.Description = product.Item.Split('|')[1].Trim();

            return this;
        }
        public int ItemId { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public double RetailPrice { get; set; }
        public List<TaxModel> TaxData { get; set; }
        public string Unit { get; set; }
        public double Amount { get; set; }

    }
}
