using System;

namespace ShoppingBird.Fly.Models
{
    public class PriceList
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public string Barcode { get; set; }
        public Tax Tax { get; set; }
        public Store Store { get; set; }
        public decimal RetailPrice { get; set; }
        public Units Unit { get; set; }
    }
}
