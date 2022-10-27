using ShoppingBird.Desktop.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.ViewModels
{
    public interface ICartViewModel
    {
        List<ItemListAllModel> ItemSearchDatasource { get; set; }
        int SelectedItemId{get;set; }
        int SelectedStoreId { get; set; }
        List<StoreModel> AllStores { get; set; }
        BindingList<CartItemModel> AllCartItems { get; set; }
        decimal TotalCartAmount { get; set; }
        decimal AdjustmentAmount { get; set; }

        Task AddSelectedItemToCart();
        void CalculateTotalCartAmount();
        void SaveCurrentCart();
    }
}