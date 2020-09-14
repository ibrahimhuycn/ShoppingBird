using System;

namespace ShoppingBird.Mobile.Models
{
    public class ItemNotFoundArgs : EventArgs
    {
        public StoreModel SelectedStore { get; set; }
        public string Barcode { get; set; }
    }
}
