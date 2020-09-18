using Newtonsoft.Json;
using ShoppingBird.Fly;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingBird.Mobile.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private StoreModel _selectedStore;
        private string _selectedProduct;
        private readonly IStoreIO _storeIO;
        private readonly IItemIO _itemIO;

        public EventHandler<string> DisplayAlert;
        public EventHandler BarcodeRead;
        public EventHandler<ItemNotFoundArgs> ItemNotFound;
        public EventHandler<AsyncVoidMethodBuilder> CheckForSavedData;
        public delegate void OnSaveCurrentState(object sender, EventArgs e);
        public event OnSaveCurrentState SaveCurrentState;
        public ICommand ExecuteSearchCommand { get; set; }
        public ICommand CheckOutCommand { get; set; }
        public ICommand RemoveSelectedItemCommand { get; set; }
        private double _total;
        private int? _selectedStoreIndex;

        public MainPageViewModel()
        {
            AllStores = new List<StoreModel>();
            AllProducts = new List<Product>();
            CartItems = new ObservableCollection<CartItem>();
            this.Total = 0d;
            //load demo data
            //LoadDemoData();
            _storeIO = new StoreIO();
            _itemIO = new ItemIO();
            InitializeCart();

            //act OnBarcodeRead
            ExecuteSearchCommand = new Command(OnSearch);
            CheckOutCommand = new Command(CheckOut, CanCheckOut);
            RemoveSelectedItemCommand = new Command(RemoveItem, CanRemoveItem);
            BarcodeRead += OnBarcodeRead_ReCalculateTotal;
            SaveCurrentState += MainPageViewModel_SaveCurrentState;
            CheckForSavedData += CheckForSavedInvoice;
            BarcodeRead?.Invoke(this, EventArgs.Empty);

            PropertyChanged += MainPageViewModel_PropertyChanged;
        }

        private void MainPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (CheckOutCommand as Command).ChangeCanExecute();
        }

        private bool CanCheckOut()
        {
            return CartItems.Count > 0;
        }

        private void CheckOut()
        {

        }
        private void InitializeCart()
        {
            //load all products data
            LoadAllProductsData();
            //load all stores
            LoadAllStores();
        }

        private void LoadAllStores()
        {
            var stores = _storeIO.GetAllStores();
            foreach (var store in stores)
            {
                this.AllStores.Add(new StoreModel()
                {
                    Id = store.Id,
                    Name = store.Name,
                    IsTaxInclusive = store.IsTaxInclusive
                });
            }
        }

        private void LoadAllProductsData()
        {
            var products = _itemIO.GetAllItemDescriptions();
            foreach (var item in products)
            {
                this.AllProducts.Add(new Product() { Id = item.Id, Item = item.Item });
            }
        }

        private async void CheckForSavedInvoice(object sender, AsyncVoidMethodBuilder e)
        {
            var SavedData = await ReadSaved();
            if (!string.IsNullOrEmpty(SavedData))
            {
                var invoiceData = LoadSavedData(SavedData);
                DisplaySavedData(invoiceData);
                OnBarcodeRead_ReCalculateTotal(this, EventArgs.Empty);
            }
        }

        private void DisplaySavedData(List<CartItem> invoiceData)
        {
            if (invoiceData is null || invoiceData.Count == 0) return;
            this.SelectedStoreIndex = GetStoreIndexByName(invoiceData.FirstOrDefault().Store.Name);

            foreach (var item in invoiceData)
            {
                this.CartItems.Add(item);
            }
        }

        private int? GetStoreIndexByName(string name)
        {
            var storeIndex = AllStores.FindIndex((x) => x.Name == name);
            if (storeIndex == -1 )
            {
                return null;
            }
            else
            {
                return storeIndex;
            }
        }

        private List<CartItem> LoadSavedData(string savedJsonData)
        {
            return JsonConvert.DeserializeObject<List<CartItem>>(savedJsonData);
        }

        public List<StoreModel> AllStores { get; set; }
        public StoreModel SelectedStore
        {
            get => _selectedStore; set
            {
                if (_selectedStore == value) return;
                _selectedStore = value;
                Debug.WriteLine(_selectedStore.ToString());
                NotifyPropertyChanged();
            }
        }
        public int? SelectedStoreIndex
        {
            get => _selectedStoreIndex; set
            {
                if (_selectedStoreIndex == value) return;
                _selectedStoreIndex = value;
                SelectedStore = AllStores.Where((x) => x.Id == _selectedStoreIndex+1).FirstOrDefault();
                if (SelectedStore is null)
                {
                    _selectedStoreIndex = null;
                }
                NotifyPropertyChanged();
            }
        }

        public List<Product> AllProducts { get; set; }
        public string SelectedProduct
        {
            get => _selectedProduct; set
            {
                if (_selectedProduct == value) return;
                _selectedProduct = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<CartItem> CartItems { get; set; }
        public double Total
        {
            get => _total; set
            {
                if (_total == value) return;
                _total = value;
                NotifyPropertyChanged();
            }
        }
        public void OnSearch()
        {
            //check if store is selected
            if (!IsStoreSelected())
            {
                SelectedProduct = "";
                DisplayAlert?.Invoke(this, "Please select a store first!");
                return;
            }

            var barcode = SelectedProduct.Split('|')[0].Trim();
            var item = AllProducts.FindAll((x) => x.Item.Split('|')[0].Trim() == barcode).FirstOrDefault();
            Debug.WriteLine("Current barcode: " + barcode);

            if (item is null)
            {
                if (string.IsNullOrEmpty(SelectedProduct)) return;
                ItemNotFound?.Invoke(this, new ItemNotFoundArgs() 
                {
                    SelectedStore = this.SelectedStore,
                    Barcode = barcode
                });
                return;
            }

            //if item exists in cart, increase quantity...
            if (!IsItemInCart(barcode))
            {
                //otherwise add item to cart
                AddItemToCart(item);
            }

            SelectedProduct = null;
            //Up UI and calculations on reading barcode
            BarcodeRead?.Invoke(this, EventArgs.Empty);
            SaveCurrentState?.Invoke(this, EventArgs.Empty);

        }

        /// <summary>
        /// Check whether the item for the barcode is present in cart
        /// if present, increases the quantity
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns>returns true if item is in cart, after increasing the quantity</returns>
        private bool IsItemInCart(string barcode)
        {
            //search for the item in cart
            var item = CartItems.Where((x) => x.Barcode == barcode).FirstOrDefault();

            //if item is not in cart return false....
            if (item is null)
            {
                return false;
            }
            else
            {
                //otherwise increase qty by 1 and return true
                item.Quantity += 1;
                return true;
            }
        }

        private async void MainPageViewModel_SaveCurrentState(object sender, EventArgs e)
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "Cart.json");
            using (var writer = File.CreateText(backingFile))
            {
                await writer.WriteLineAsync(JsonConvert.SerializeObject(CartItems,
                    Formatting.Indented));
            }
        }

        private async Task<string> ReadSaved()
        {
            string line = "";
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "Cart.json");

            if (backingFile == null || !File.Exists(backingFile))
            {
                return "";
            }

            using (var reader = new StreamReader(backingFile, true))
            {
                line = await reader.ReadToEndAsync();
            }
            Debug.WriteLine(line);
            return line;
        }

        internal void RemoveItem()
        {
            if (item.Quantity > 1)
            {
                item.Quantity -= 1;
                return;
            }

            CartItems.Remove(item);

            //update total price display
            OnBarcodeRead_ReCalculateTotal(this, EventArgs.Empty);
            SaveCurrentState?.Invoke(this, EventArgs.Empty);
        }

        private bool CanRemoveItem()
        {
            return !string.IsNullOrEmpty(SelectedProduct);
        }

        private void OnBarcodeRead_ReCalculateTotal(object sender, EventArgs e)
        {
            Total = 0d;
            foreach (var item in CartItems)
            {
                Total += item.Amount;
            }
        }

        private void LoadDemoData()
        {
            //shops data
            var samraahi = new StoreModel() { Id = 1, Name = "Samraahi", IsTaxInclusive = false };
            var seeds = new StoreModel() { Id = 2, Name = "Seeds", IsTaxInclusive = true };
            AllStores.Add(samraahi);
            AllStores.Add(seeds);

            //products data
            var shampoo = new Product() { Id = 1, Item = "4902430401135 | PANTENE Anti-Dandruff Shampoo" };
            var reader = new Product() { Id = 2, Item = "49024304012736 | Generic barcode reader" };
            var hairdryer = new Product() { Id = 3, Item = "6941595101588 | Folding Hair dryer 3007 EUROPEAN STANDARD" };
            AllProducts.Add(shampoo);
            AllProducts.Add(reader);
            AllProducts.Add(hairdryer);

        }
        /// <summary>
        /// Adds the passed in item to cart
        /// </summary>
        /// <param name="item"></param>
        private void AddItemToCart(Product item)
        {
            var barcode  = item.Item.Split('|')[0].Trim();
            var searchData = _itemIO.SearchItem(new Fly.Models.ItemSearchTerms(barcode, SelectedStore.Id));
            if (!string.IsNullOrEmpty(searchData.ErrorMessage))
            {
                DisplayAlert?.Invoke(this, searchData.ErrorMessage);
                return;
            }
            var price = double.Parse(searchData.RetailPrice.ToString());
            var taxRate = double.Parse(searchData.Rate.ToString());
            var cartItem = new CartItem().GetPartialInvoiceItem(item,price,taxRate);
            cartItem.Store = SelectedStore;
            CartItems.Add(cartItem);
            Debug.WriteLine("Item Added to cart");
        }

        /// <summary>
        /// Check whether store is selected
        /// </summary>
        /// <returns>True if store is selected</returns>
        private bool IsStoreSelected()
        {
            return SelectedStore is null ? false : !string.IsNullOrEmpty(SelectedStore.Name);
        }

    }
}
