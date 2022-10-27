using AutoMapper;
using Shopping.Desktop.Models;
using ShoppingBird.Desktop.Exceptions;
using ShoppingBird.Desktop.Helpers;
using ShoppingBird.Desktop.Models;
using ShoppingBird.Desktop.Transations;
using ShoppingBird.Fly.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.ViewModels
{
    public class CartViewModel : NotifyBase, ICartViewModel
    {
        private readonly IItemIO _itemIO;
        private readonly IStoreIO _storeIO;
        private readonly IInvoiceIO _invoiceIO;
        private readonly IMapper _mapper;
        private int _selectedItemId;
        private int _selectedStoreId;
        private decimal _totalCartAmount;
        private decimal _adjustmentAmount;

        private event EventHandler OnInitializing;
        private event EventHandler OnItemAddedToCart;
        private event EventHandler OnSaveCartRequested;

        public CartViewModel(IItemIO itemIO, IStoreIO storeIO,IInvoiceIO invoiceIO, IMapper mapper)
        {
            _itemIO = itemIO;
            _storeIO = storeIO;
            _invoiceIO = invoiceIO;
            _mapper = mapper;
            ItemSearchDatasource = new List<ItemListAllModel>();
            AllStores = new List<StoreModel>();
            AllCartItems = new BindingList<CartItemModel>();
            AdjustmentAmount = 0.0000m;

            OnInitializing += CartViewModel_OnInitializing;
            OnItemAddedToCart += CalculateTotalCartAmount;
            OnSaveCartRequested += CartViewModel_OnSaveCartRequested;
            OnInitializing?.Invoke(this, EventArgs.Empty);
        }

        public List<ItemListAllModel> ItemSearchDatasource { get; set; }
        public BindingList<CartItemModel> AllCartItems { get; set; }
        public List<StoreModel> AllStores { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal AdjustmentAmount
        {
            get => _adjustmentAmount; set
            {
                _adjustmentAmount = value;
                OnPropertyChanged();
                CalculateTotalCartAmount(this, EventArgs.Empty);
            }
        }
        public int SelectedItemId
        {
            get => _selectedItemId; set
            {
                _selectedItemId = value;
                OnPropertyChanged();
            }
        }
        public int SelectedStoreId
        {
            get => _selectedStoreId; set
            {
                _selectedStoreId = value;
                OnPropertyChanged();
            }
        }
        public decimal TotalCartAmount
        {
            get => _totalCartAmount; set
            {
                _totalCartAmount = value;
                OnPropertyChanged();
            }
        }

        #region Public Methods
        public void SaveCurrentCart()
        {
            OnSaveCartRequested?.Invoke(this, EventArgs.Empty);
        }
        public void CalculateTotalCartAmount()
        {
            CalculateTotalCartAmount(this, EventArgs.Empty);
        }

        public async Task AddSelectedItemToCart()
        {
            try
            {
                if (SelectedItemId <= 0) { throw new NoItemSelectedException(GlobalStrings.CartView_NoItemSelected); }
                if (SelectedStoreId <= 0) { throw new NoStoreSelectedException(GlobalStrings.CartView_NoStoreSelected); }

                var item = await _itemIO.GetItemByItemIdAndStoreIdAsync(SelectedItemId, SelectedStoreId);
                if (item is null) { throw new CartItemNotFoundForStoreException(); }
                var mapped = _mapper.Map<CartItemModel>(item);
                AddItemToDisplayCart(mapped);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                SelectedItemId = -1;
            }

        }

        private void AddItemToDisplayCart(CartItemModel item)
        {
            try
            {
                var existingItem = AllCartItems.FirstOrDefault(x => x.ItemId == item.ItemId);
                if (existingItem is null) { AllCartItems.Add(item); return; }
            }
            finally
            {
                OnItemAddedToCart?.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Private Methods
        private async void CartViewModel_OnInitializing(object sender, EventArgs e)
        {
            await LoadItemsSearchDataAsync();
            await LoadAllStoresAsync();
        }
        private async Task LoadAllStoresAsync()
        {
            AllStores.Clear();
            var stores = await _storeIO.GetAllStoresAsync();
            var mapped = _mapper.Map<List<StoreModel>>(stores);
            AllStores.AddRange(mapped);
        }
        private async Task LoadItemsSearchDataAsync()
        {
            var data = await _itemIO.GetAllItemDescriptionsAsync();
            var mapped = _mapper.Map<List<ItemListAllModel>>(data);
            ItemSearchDatasource.AddRange(mapped);
        }
        private void CalculateTotalCartAmount(object sender, EventArgs e)
        {
            var totalAmount = 0m;
            foreach (var item in AllCartItems)
            {
                item.Amount = item.Quantity * item.RetailPrice;
                totalAmount += item.Amount;
            }

            TotalCartAmount = totalAmount + AdjustmentAmount;
        }

        private async void CartViewModel_OnSaveCartRequested(object sender, EventArgs e)
        {
            var invoiceModel = new NewInvoiceModel()
            {
                Invoice = new InvoiceModel()
                {
                    StoreId = SelectedStoreId,
                    Number = InvoiceNumber
                }
            };
            await _invoiceIO.SaveInvoiceAsync(new Fly.Models.NewInvoiceModel());
        }

        #endregion

    }
}
