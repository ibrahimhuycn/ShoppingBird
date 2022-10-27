using System;

namespace ShoppingBird.Fly.Models
{
    public class ItemPriceData
    {
        public ItemPriceData()
        {
            Item = new Item();
            Tax = new Tax();
            Store = new StoreModel();
            Unit = new Units();
        }
        public int Id { get; set; }
        public Item Item { get; set; }
        public string Barcode { get; set; }
        public Tax Tax { get; set; }
        public StoreModel Store { get; set; }
        public decimal RetailPrice { get; set; }
        public Units Unit { get; set; }
    }
}
