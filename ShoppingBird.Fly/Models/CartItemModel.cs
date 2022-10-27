namespace ShoppingBird.Fly.Models
{
    public class CartItemModel
    {
        public CartItemModel()
        {
            Quantity = 1;
        }
        public string Barcode { get; set; }
        public int ItemId { get; set; }
        public int StoreId { get; set; }
        public decimal RetailPrice { get; set; }
        public string ItemDescription { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
    }
}
