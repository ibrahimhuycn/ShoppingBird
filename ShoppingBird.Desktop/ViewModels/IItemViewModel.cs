using ShoppingBird.Desktop.Models;
using System.ComponentModel;

namespace ShoppingBird.Desktop.ViewModels
{
    public interface IItemViewModel
    {
        BindingList<ItemListAllModel> AllItems { get; set; }
        ItemListAllModel SelectedItem { get; set; }
        string SelectedItemDescription { get; set; }
        int? SelectedItemId { get; set; }
    }
}