using AutoMapper;
using ShoppingBird.Desktop.Helpers;
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
    public class ItemStorePricesViewModel : NotifyBase, IItemStorePricesViewModel
    {
        #region Private Fields

        private readonly IStoreIO _storeIO;
        private readonly IUnitsIO _unitsIO;
        private readonly IItemIO _itemIO;
        private readonly IPriceListIO _priceListIO;
        private readonly IMapper _mapper;
        private StoreModel _selectedStoreModel;
        private UnitsModel _selectedUnitsModel;
        private ItemListAllModel _selectedItemModel;
        private string _selectedItemDescription;
        private string _selectedBarcode;
        private string _selectedStoreName;
        private string _selectedUnit;
        private PriceListModel _selectedPriceListModel;
        private decimal _selectedItemRetailPrice;
        private bool _isAnExistingPriceSelected;
        #endregion

        private event EventHandler OnInitialize;
        #region Constructor
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
        #endregion

        #region Public properties

        public BindingList<StoreModel> AllStores { get; set; }
        public BindingList<UnitsModel> AllUnits { get; set; }
        public BindingList<ItemListAllModel> AllItems { get; set; }
        public BindingList<PriceListModel> AllPricesForAllStores { get; set; }

        public StoreModel SelectedStoreModel
        {
            get => _selectedStoreModel; set
            {
                _selectedStoreModel = value;
                if (value is null) { return; }
                SelectedStoreId = value.Id;
                SelectedStoreName = value.Name;
            }
        }
        public UnitsModel SelectedUnitsModel
        {
            get => _selectedUnitsModel; set
            {
                _selectedUnitsModel = value;
                if (value is null) { return; }
                SelectedUnitId = value.Id;
                SelectedUnit = value.Unit;
            }
        }
        public ItemListAllModel SelectedItemModel
        {
            get => _selectedItemModel; set
            {
                _selectedItemModel = value;
                SelectedItemId = value.Id;
                IsAnExistingPriceSelected = false;

                if (value?.Item.Contains("|") == false) { return; }
                var barcodeAndDesc = value.Item.Split('|');

                SelectedBarcode = barcodeAndDesc[0];
                SelectedItemDescription = barcodeAndDesc[1];
                SelectedItemRetailPrice = 0.0000m;
            }
        }
        public PriceListModel SelectedPriceListModel
        {
            get => _selectedPriceListModel; set
            {
                _selectedPriceListModel = value;
                IsAnExistingPriceSelected = true;

                if (value is null) { return; }

                SelectedBarcode = value.Barcode;
                SelectedItemRetailPrice = value.RetailPrice;
                SelectedItemDescription = value.ItemDescription;

                var store = AllStores.FirstOrDefault(x=> x.Name == value.StoreDescription);
                SelectedStoreModel = store;

                var unit = AllUnits.FirstOrDefault(x=> x.Id == value.UnitId);
                SelectedUnitsModel = unit;
            }
        }

        /// <summary>
        /// This will determine what happens when save action is requested
        /// TRUE: Will update existing price
        /// FALSE: will insert new price for selected item and store
        /// </summary>
        public bool IsAnExistingPriceSelected
        {
            get => _isAnExistingPriceSelected; set
            {
                _isAnExistingPriceSelected = value;
                OnPropertyChanged();
            }
        }

        public string SelectedBarcode
        {
            get => _selectedBarcode; set
            {
                _selectedBarcode = value;
                OnPropertyChanged();
            }
        }
        public int SelectedItemId { get; set; }
        public string SelectedItemDescription
        {
            get => _selectedItemDescription; set
            {
                _selectedItemDescription = value;
                OnPropertyChanged();
            }
        }
        public int SelectedStoreId { get; set; }
        public string SelectedStoreName
        {
            get => _selectedStoreName; set
            {
                _selectedStoreName = value;
                OnPropertyChanged();
            }
        }
        public int SelectedUnitId { get; set; }
        public string SelectedUnit
        {
            get => _selectedUnit; set
            {
                _selectedUnit = value;
                OnPropertyChanged();
            }
        }
        public decimal SelectedItemRetailPrice
        {
            get => _selectedItemRetailPrice; set
            {
                _selectedItemRetailPrice = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Public Methods
        public async Task InsertOrUpdateStorePriceDataAsync()
        {
            if (IsAnExistingPriceSelected)
            {
                await UpdateSelectedStorePriceDataAsync();
                return;
            }
            await InsertNewPriceDataAsync();
        }

        private async Task InsertNewPriceDataAsync()
        {
            var inserted  = await _priceListIO.InsertPriceListRecordAsync
                (SelectedItemId, SelectedBarcode, SelectedStoreId, SelectedItemRetailPrice, SelectedUnitId);
            var mapped = _mapper.Map<PriceListModel>(inserted);
            AllPricesForAllStores.Add(mapped);
            NotificationHelper.ShowMessage("Item inserted successfully", "STORE PRICE INSERTED");
        }

        private async Task UpdateSelectedStorePriceDataAsync()
        {
            var updated = await _priceListIO.UpdateStorePriceAsync
                (SelectedPriceListModel.Id, SelectedBarcode, SelectedItemRetailPrice);
            var storeItemPriceData = AllPricesForAllStores.FirstOrDefault(x=> x.Id == updated.Id);

            storeItemPriceData.Barcode = updated.Barcode;
            storeItemPriceData.RetailPrice = updated.RetailPrice;

            NotificationHelper.ShowMessage("Item updated successfully", "RECORD UPDATED");
        }
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
            var allItems = await _itemIO.GetAllItemDescriptionsWithIdAndBarcodeAsync();
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
