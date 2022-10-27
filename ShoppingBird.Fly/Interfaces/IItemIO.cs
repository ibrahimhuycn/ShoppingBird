using ShoppingBird.Fly.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IItemIO
    {
        Task<List<ItemListAllModel>> GetAllItemDescriptionsAsync();
        Task<CartItemModel> GetItemByItemIdAndStoreIdAsync(int selectedItemId, int selectedStoreId);
    }
}
