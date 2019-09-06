using System;

namespace ShoppingBird.Fly.Models
{
    public class ItemSearchTerms : PriceList
    {

        private SearchBy _searchBy;
        /// <summary>
        /// Sets up item search by barcode and description. 
        /// WARNING: Both barcode and description cannot be null at the same time. This will throw an exception.
        /// </summary>
        /// <param name="barcode">Item barcode to be searched with</param>
        /// <param name="description"> The item description to be searched with</param>
        public ItemSearchTerms(string barcodeOrDescription, bool isSearchByBarcode = true)
        {
            switch (isSearchByBarcode)
            {
                case true:
                    this.Barcode = barcodeOrDescription;
                    this._searchBy = SearchBy.Barcode;
                    break;
                case false:
                    this.Barcode = barcodeOrDescription;
                    this._searchBy = SearchBy.Description;
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

