using ShoppingBird.Desktop.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.ViewModels
{
    public interface IItemStorePricesViewModel
    {
        BindingList<ItemListAllModel> AllItems { get; set; }
        BindingList<PriceListModel> AllPricesForAllStores { get; set; }
        BindingList<StoreModel> AllStores { get; set; }
        BindingList<UnitsModel> AllUnits { get; set; }
        ItemListAllModel SelectedItemModel { get; set; }
        string SelectedItemDescription { get; set; }
        string SelectedBarcode { get; set; }
        string SelectedStoreName { get; set; }
        StoreModel SelectedStoreModel { get; set; }
        UnitsModel SelectedUnitsModel { get; set; }
        string SelectedUnit { get; set; }
        PriceListModel SelectedPriceListModel { get; set; }
        decimal SelectedItemRetailPrice { get; set; }
        bool IsAnExistingPriceSelected { get; set; }

        Task InsertOrUpdateStorePriceDataAsync();
        void Refresh();
    }
}