using ShoppingBird.Fly.Models;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IItemIO
    {
        List<ItemListAllModel> GetAllItemDescriptions();
        object GetItemByItemIdAndStoreId(int selectedItemId, int selectedStoreId);
    }
}
