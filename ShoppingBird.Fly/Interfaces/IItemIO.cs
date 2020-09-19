using ShoppingBird.Fly.Models;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IItemIO
    {
        int SaveItem(ItemInsertDataArgs e);
        ItemSearchResultModel SearchItem(ItemSearchTerms e);
        List<ItemListAllModel> GetAllItemDescriptions();
        List<SearchResultsAllPriceDataForItemModel> SearchAllPriceDataForItem(string itemDescription);
        ItemInsertAssistDataModel GetInsertAssistData(string barcode, int storeId);
        ItemDataModel GetItemDataByBarcode(string barcode);
    }
}
