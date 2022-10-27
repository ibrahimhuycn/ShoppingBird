using System;

namespace ShoppingBird.Fly.Models
{
    public class ItemPriceDataModel
    {
        public ItemPriceDataModel()
        {
            Item = new ItemModel();
            Store = new StoreModel();
            Unit = new UnitsModel();
        }
        public int Id { get; set; }
        public ItemModel Item { get; set; }
        public string Barcode { get; set; }
        public StoreModel Store { get; set; }
        public decimal RetailPrice { get; set; }
        public UnitsModel Unit { get; set; }
    }
}
