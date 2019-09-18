using System;

namespace ShoppingBird.Fly.Models
{
    public class ItemSearchTerms : ItemPriceData
    {

        private SearchBy _searchBy;
        /// <summary>
        /// Sets up item search by barcode and description. 
        /// WARNING: Both barcode and description cannot be null at the same time. This will throw an exception.
        /// </summary>
        /// <param name="barcode">Item barcode to be searched with</param>
        /// <param name="description"> The item description to be searched with</param>
        /// <param name="store">This is the selected store Id</param>
        public ItemSearchTerms(string barcodeOrDescription, int storeId, bool isSearchByBarcode = true)
        {

            switch (isSearchByBarcode)
            {
                case true:
                    this.Barcode = barcodeOrDescription;
                    this._searchBy = SearchBy.Barcode;
                    this.Store.Id = storeId;
                    break;
                case false:
                    this.Item.Description = barcodeOrDescription;
                    this._searchBy = SearchBy.Description;
                    this.Store.Id = storeId;
                    break;

            }
        }
        public SearchBy searchBy
        {
            get
            {
                return _searchBy;
            }
        }

    }

}

