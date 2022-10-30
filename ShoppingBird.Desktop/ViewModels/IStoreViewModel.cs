using ShoppingBird.Desktop.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.ViewModels
{
    public interface IStoreViewModel
    {
        BindingList<StoreModel> AllStores { get; set; }
        int SelectedStoreId { get; set; }
        string SelectedStoreName { get; set; }

        Task SaveStoreAsync();
        void SetStoreInsertMode();
    }
}