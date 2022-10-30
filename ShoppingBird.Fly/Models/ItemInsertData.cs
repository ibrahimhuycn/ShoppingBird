using System;
namespace ShoppingBird.Fly.Models
{
    public class ItemInsertDataArgs : EventArgs
    {
        private readonly ItemModel _item;
        private readonly ItemPriceDataModel _priceData;

        public ItemInsertDataArgs(ItemModel item, ItemPriceDataModel itemPriceData)
        {
            this._item = item;
            this._priceData = itemPriceData;
        }

        public ItemModel Item
        {
            get
            {
                return _item;
            }
        }
        public ItemPriceDataModel PriceData
        {
            get
            {
                return _priceData;
            }
        }
    }
}
