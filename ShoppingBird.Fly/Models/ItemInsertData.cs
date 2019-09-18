using System;
namespace ShoppingBird.Fly.Models
{
    public class ItemInsertDataArgs : EventArgs
    {
        private readonly Item _item;
        private readonly ItemPriceData _priceData;

        public ItemInsertDataArgs(Item item, ItemPriceData itemPriceData)
        {
            this._item = item;
            this._priceData = itemPriceData;
        }

        public Item Item
        {
            get
            {
                return _item;
            }
        }
        public ItemPriceData PriceData
        {
            get
            {
                return _priceData;
            }
        }
    }
}
