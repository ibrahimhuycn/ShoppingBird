using AutoMapper;
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
    public class ItemStorePricesViewModel : IItemStorePricesViewModel
    {
        private readonly IStoreIO _storeIO;
        private readonly IUnitsIO _unitsIO;
        private readonly IItemIO _itemIO;
        private readonly IPriceListIO _priceListIO;
        private readonly IMapper _mapper;

        private event EventHandler OnInitialize;
        public ItemStorePricesViewModel(IStoreIO storeIO, IUnitsIO unitsIO, IItemIO itemIO, IPriceListIO priceListIO, IMapper mapper)
        {
            _storeIO = storeIO;
            _unitsIO = unitsIO;
            _itemIO = itemIO;
            _priceListIO = priceListIO;
            _mapper = mapper;
            AllStores = new BindingList<StoreModel>();
            AllUnits = new BindingList<UnitsModel>();
            AllItems = new BindingList<ItemListAllModel>();
            AllPricesForAllStores = new BindingList<PriceListModel>();

            OnInitialize += ItemStorePricesViewModel_OnInitialize;
            OnInitialize?.Invoke(this, EventArgs.Empty);
        }

        #region Public properties

        public BindingList<StoreModel> AllStores { get; set; }
        public BindingList<UnitsModel> AllUnits { get; set; }
        public BindingList<ItemListAllModel> AllItems { get; set; }
        public BindingList<PriceListModel> AllPricesForAllStores { get; set; }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        private async void ItemStorePricesViewModel_OnInitialize(object sender, EventArgs e)
        {
            try
            {
                await LoadAllStoresAsync();
                await LoadAllUnitsAsync();
                await LoadAllItemsAsync();
                await LoadAllPricesForAllStoresAsync();
            }
            catch (Exception ex)
            {
                Helpers.NotificationHelper.ShowMessage(ex, "Error Initializing [ Item Store Prices View ]");
            }
        }

        private async Task LoadAllPricesForAllStoresAsync()
        {
            var allPrricesForAllStores = await _priceListIO.GetAllPricesForAllStoresWithUnitsAsync();
            var mapped = _mapper.Map<List<PriceListModel>>(allPrricesForAllStores);
            foreach (var item in mapped)
            {
                AllPricesForAllStores.Add(item);
            }
        }

        private async Task LoadAllItemsAsync()
        {
            var allItems = await _itemIO.GetAllItemDescriptionsAsync();
            var mapped = _mapper.Map<List<ItemListAllModel>>(allItems);
            foreach (var item in mapped)
            {
                AllItems.Add(item);
            }
        }

        private async Task LoadAllUnitsAsync()
        {
            var allUnits = await _unitsIO.LoadAllUnitsAsync();
            var mapped = _mapper.Map<List<UnitsModel>>(allUnits);
            foreach (var item in mapped)
            {
                AllUnits.Add(item);
            }
        }

        private async Task LoadAllStoresAsync()
        {
            var allStores = await _storeIO.GetAllStoresAsync();
            var mapped = _mapper.Map<List<StoreModel>>(allStores);
            foreach (var item in mapped)
            {
                AllStores.Add(item);
            }
        }
        #endregion
    }
}
