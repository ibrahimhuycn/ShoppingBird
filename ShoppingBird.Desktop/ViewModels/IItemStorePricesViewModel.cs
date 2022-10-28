using ShoppingBird.Desktop.Models;
using System.ComponentModel;

namespace ShoppingBird.Desktop.ViewModels
{
    public interface IItemStorePricesViewModel
    {
        BindingList<ItemListAllModel> AllItems { get; set; }
        BindingList<PriceListModel> AllPricesForAllStores { get; set; }
        BindingList<StoreModel> AllStores { get; set; }
        BindingList<UnitsModel> AllUnits { get; set; }
    }
}