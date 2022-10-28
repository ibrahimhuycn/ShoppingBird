using ShoppingBird.Desktop.Models;
using ShoppingBird.Fly.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.ViewModels
{
    public class ItemStorePricesViewModel
    {
        private readonly IStoreIO _storeIO;
        private readonly IUnitsIO _unitsIO;
        private readonly IItemIO _itemIO;

        public ItemStorePricesViewModel(IStoreIO storeIO, IUnitsIO unitsIO, IItemIO itemIO)
        {
            _storeIO = storeIO;
            _unitsIO = unitsIO;
            _itemIO = itemIO;

            AllStores = new BindingList<StoreModel>();
            AllUnits =new BindingList<UnitsModel>();
        }

        public BindingList<StoreModel> AllStores { get; set; }
        public BindingList<UnitsModel> AllUnits { get; set; }
    }
}
