using ShoppingBird.Fly.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IItemIO
    {
        Task<List<ItemListAllModel>> GetAllItemDescriptionsWithIdAndBarcodeAsync();
        Task<List<ItemListAllModel>> GetAllItemsWithDescriptionAsync();
        Task<CartItemModel> GetItemByItemIdAndStoreIdAsync(int selectedItemId, int selectedStoreId);
        Task<ItemModel> InsertItemAsync(string selectedItemDescription);
        Task<ItemModel> UpdateItemAsync(int id, string description);
    }
}
