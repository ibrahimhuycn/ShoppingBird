using Shopping.Desktop.Models;
using System.Collections.Generic;

namespace Shopping.Desktop.ViewModels
{
    public interface ICartViewModel
    {
        List<ItemListAllModel> ItemSearchDatasource { get; set; }
        int SelectedItemId{get;set; }
        int SelectedStoreId { get; set; }

        void AddSelectedItemToCart();
    }
}