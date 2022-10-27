using Shopping.Desktop.Models;
using System.Collections.Generic;

namespace Shopping.Desktop.ViewModels
{
    public interface ICartViewModel
    {
        List<ItemListAllModel> ItemSearchDatasource { get; set; }
    }
}