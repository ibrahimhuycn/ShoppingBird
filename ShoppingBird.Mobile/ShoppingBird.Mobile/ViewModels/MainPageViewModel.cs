using Newtonsoft.Json;
using ShoppingBird.Fly;
using ShoppingBird.Fly.DbModels;
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
        private readonly IInvoiceIO _invoiceIO;
        private readonly ITaxIO _taxIO;

        public event EventHandler<string> DisplayAlert;
        public event EventHandler<ToastModel> DisplayToast;
        public EventHandler<PromptModel> DisplayPrompt;
        public EventHandler BarcodeRead;
        public EventHandler<ItemNotFoundArgs> ItemNotFound;
        public EventHandler<AsyncVoidMethodBuilder> CheckForSavedData;
        public EventHandler<AddPriceForStoreArgs> InitiateAddPriceData;
        public event EventHandler<EditItemArgs> InitiateEditSelectedItem;
        public delegate void OnSaveCurrentState(object sender, EventArgs e);
        public event OnSaveCurrentState SaveCurrentState;
        public ICommand ExecuteSearchCommand { get; set; }
        public ICommand CheckOutCommand { get; set; }
        public ICommand RemoveSelectedItemCommand { get; set; }
        public ICommand CartItemSelectionChanged { get; set; }
        public ICommand IncreaseQtyCommand { get; set; }
        public ICommand EditItemCommand { get; set; }
        private double _total;
        private int? _selectedStoreIndex;
        private CartItem _selectedCartItem;
        private int? _selectedCartItemIndex;

        public MainPageViewModel()
        {
            AllStores = new List<StoreModel>();
            AllProducts = new List<Product>();
            CartItems = new ObservableCollection<CartItem>();
            AllTax = new List<TaxModel>();
            this.Total = 0d;
            //LoadDemoData();
            _storeIO = new StoreIO();
            _itemIO = new ItemIO();
            _invoiceIO = new InvoiceIO();
            _taxIO = new TaxIO();

            //act OnBarcodeRead
            ExecuteSearchCommand = new Command(OnSearch);
            CheckOutCommand = new Command(InitiateCheckOut, CanCheckOut);
            RemoveSelectedItemCommand = new Command(RemoveItem, CanRemoveItem);
            CartItemSelectionChanged = new Command<CartItem>(SetSelectedCartItem);
            IncreaseQtyCommand = new Command<CartItem>(IncreaseSelectedItemQty, CanIncreaseItemQty);
            EditItemCommand = new Command<CartItem>(EditSelectedItem, CanEditItem);
            BarcodeRead += OnBarcodeRead_ReCalculateTotal;
            SaveCurrentState += MainPageViewModel_SaveCurrentState;
            CheckForSavedData += CheckForSavedInvoice;
            BarcodeRead?.Invoke(this, EventArgs.Empty);
            

            PropertyChanged += MainPageViewModel_PropertyChanged;
            InitializeCart();

        }

        internal void UpdateUiOnItemUpdate(EditItemArgs e)
        {
            if (e is null) return;
            var item = CartItems.First((x) => x.Barcode == e.Barcode);
            if (item is null) return;
            item.Description = e.Description;
            item.RetailPrice = e.RetailPrice;

            //update tax for cart item
            item.TaxData.Clear();
            var currentTax = AllTax.FirstOrDefault((x) => x.Id == e.ItemTaxId);
            if (currentTax != null) item.TaxData.Add(currentTax);
            item.UpdatePriceData();

            OnBarcodeRead_ReCalculateTotal(this, EventArgs.Empty);
        }

        private void EditSelectedItem(CartItem cartItem)
        {
            try
            {
                //search for item with store and barcode
                var item = _itemIO.GetItemDataByBarcode(cartItem.Barcode);
                InitiateEditSelectedItem?.Invoke(this, new EditItemArgs()
                {
                    Barcode = cartItem.Barcode,
                    CurrentStore = cartItem.Store,
                    Description = cartItem.Description,
                    ItemCatId = item.CategoryId,
                    ItemSubCatId = item.SubCategoryId,
                    ItemTaxId = item.TaxId,
                    ItemUnitId = item.UnitId,
                    RetailPrice = cartItem.RetailPrice
                });
            }
            catch (Exception ex)
            {
                DisplayToast?.Invoke(this, new ToastModel()
                {
                    Message = $"Error editing Item!\n\n{ex.Message}",
                    ToastLength = Plugin.Toast.Abstractions.ToastLength.Long,
                    Type = ToastModel.MessageType.Error
                });
            }
        }

        private void IncreaseSelectedItemQty(CartItem cartItem)
        {
            cartItem.Quantity += 1;
            OnBarcodeRead_ReCalculateTotal(this, EventArgs.Empty);
        }

        private void InitiateCheckOut()
        {
            DisplayPrompt?.Invoke(this, new PromptModel()
            {
                Header = "Invoice Id",
                Message ="Please input the invoice Id..."
            });
        }

        private void SetSelectedCartItem(CartItem item)
        {
            SelectedCartItem = item;
        }

        private void MainPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (CheckOutCommand as Command).ChangeCanExecute();
            (RemoveSelectedItemCommand as Command).ChangeCanExecute();
            (IncreaseQtyCommand as Command).ChangeCanExecute();
            (EditItemCommand as Command).ChangeCanExecute();

        }

        private bool CanCheckOut()
        {
            return CartItems.Count > 0;
        }

        //checkout the items (save the invoice)
        public void CheckOut()
        {
            //calculate subtotal and tax
            var subTotalAndTaxInvoiceDetails = CalculateSubTotalAndTax(CartItems);
            //prepare data
            var invoice = new Invoice()
            {
                 Number = InvoiceId,
                 StoreId = SelectedStore.Id,
                 SubTotal = subTotalAndTaxInvoiceDetails[0],
                 Tax = subTotalAndTaxInvoiceDetails[1],
                 Total = decimal.Parse(Total.ToString()),
                 Date = DateTime.Now,
                 UserId =1
            };

            try
            {
                _invoiceIO.SaveInvoice(new Fly.Models.NewInvoice()
                {
                    Invoice = invoice,
                    InvoiceDetails = subTotalAndTaxInvoiceDetails[2]
                });

                ResetCart();
                DisplayToast?.Invoke(this, new ToastModel() 
                { 
                    Message= "Successfully saved the invoice.",
                    Type = ToastModel.MessageType.Success,
                    ToastLength = Plugin.Toast.Abstractions.ToastLength.Long 
                });
                MainPageViewModel_SaveCurrentState(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                DisplayAlert?.Invoke(this, ex.Message);
            }

        }

        /// <summary>
        /// removes cart items and deselects the selected store
        /// </summary>
        private void ResetCart()
        {
            CartItems.Clear();
            SelectedStoreIndex = -1;
            OnBarcodeRead_ReCalculateTotal(this, EventArgs.Empty);
        }

        /// <summary>
        /// Calculates subtotal and tax and invoiceDetails list
        /// </summary>
        /// <returns>Returns a decimal array where index 0 is sub total, 1 is Tax, 2 is InvoiceDetails model</returns>
        private dynamic[] CalculateSubTotalAndTax(ObservableCollection<CartItem> cartItems)
        {
            var subTotalAndTaxInvoiceDetails = new dynamic[3] { new decimal(), new decimal(), new List<InvoiceDetail>() };
            foreach (var item in cartItems)
            {
                subTotalAndTaxInvoiceDetails[0] += decimal.Parse(item.RetailPrice.ToString());
                subTotalAndTaxInvoiceDetails[1] += decimal.Parse(item.TaxAmount.ToString());
                subTotalAndTaxInvoiceDetails[2].Add(new InvoiceDetail()
                {
                    ItemId = item.ItemId,
                    Price = decimal.Parse(item.RetailPrice.ToString()),
                    Quantity = item.Quantity,
                    Tax = decimal.Parse(item.TaxAmount.ToString())
                });
            }
            return subTotalAndTaxInvoiceDetails;
        }

        private void InitializeCart()
        {
            try
            {
                //load all products data
                LoadAllProductsData();
                //load all stores
                LoadAllStores();
                //load all tax
                LoadAllTax();
            }
            catch (Exception ex)
            {
                DisplayToast?.Invoke(this, new ToastModel()
                {
                    Message = ex.Message,
                    ToastLength = Plugin.Toast.Abstractions.ToastLength.Long,
                    Type = ToastModel.MessageType.Error
                });
            }

        }

        private void LoadAllTax()
        {
            var allTax = _taxIO.GetAllTax();
            foreach (var item in allTax)
            {
                AllTax.Add(new TaxModel()
                {
                    Id = item.Id,
                    Percent = double.Parse(item.Rate.ToString()),
                    Description = item.Description
                });
            }
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
                DisplayToast?.Invoke(this, new ToastModel() 
                {
                    Message = "Successfully restored incomplete invoice!",
                    ToastLength = Plugin.Toast.Abstractions.ToastLength.Long,
                    Type = ToastModel.MessageType.Success
                });
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
            if (storeIndex == -1)
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
        public List<TaxModel> AllTax { get; set; }
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
                if (value == -1)
                {
                    _selectedStore = null;
                }
                else
                {
                    SelectedStore = AllStores.Where((x) => x.Id == _selectedStoreIndex + 1).FirstOrDefault();
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
        public int? SelectedCartItemIndex
        {
            get => _selectedCartItemIndex; set
            {
                if (_selectedCartItemIndex == value) return;
                _selectedCartItemIndex = value;
                NotifyPropertyChanged();
            }
        }
        public CartItem SelectedCartItem
        {
            get => _selectedCartItem; set
            {
                if (_selectedCartItem == value) return;
                _selectedCartItem = value;
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
        public int InvoiceId { get; set; }

        public void OnSearch()
        {
            //check if store is selected
            if (!IsStoreSelected())
            {
                SelectedProduct = "";
                DisplayToast?.Invoke(this, new ToastModel()
                {
                    Message = "Please select a store first!",
                    ToastLength = Plugin.Toast.Abstractions.ToastLength.Long,
                    Type = ToastModel.MessageType.Warning
                });
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
            if (SelectedCartItem.Quantity > 1)
            {
                SelectedCartItem.Quantity -= 1;
                return;
            }

            CartItems.Remove(SelectedCartItem);
            SelectedCartItem = null;
            //update total price display
            OnBarcodeRead_ReCalculateTotal(this, EventArgs.Empty);
            SaveCurrentState?.Invoke(this, EventArgs.Empty);
        }

        private bool CanEditItem(CartItem cartItem)
        {
            return !(cartItem is null) && CartItems.Count > 0;
        }
        private bool CanIncreaseItemQty(CartItem cartItem)
        {
            return !(cartItem is null) && CartItems.Count > 0;
        }

        private bool CanRemoveItem()
        {
            return !(SelectedCartItem is null) && CartItems.Count > 0;
        }

        private void OnBarcodeRead_ReCalculateTotal(object sender, EventArgs e)
        {
            if (CartItems is null) return;
            if (CartItems.Count == 0) return;

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
            var barcode = item.Item.Split('|')[0].Trim();
            var searchData = _itemIO.SearchItem(new Fly.Models.ItemSearchTerms(barcode, SelectedStore.Id));
            if (!string.IsNullOrEmpty(searchData.ErrorMessage))
            {
                if(searchData.ErrorMessage == "PriceDataNotFoundForStore")
                {
                    AddPriceForStore(barcode);
                    return;
                }   
                
                DisplayAlert?.Invoke(this, searchData.ErrorMessage);
                return;
            }

            item.Item = $"{barcode}|{searchData.Description}";
            var price = double.Parse(searchData.RetailPrice.ToString());
            var taxRate = double.Parse(searchData.Rate.ToString());
            var cartItem = new CartItem().GetPartialInvoiceItem(item, price, taxRate);
            cartItem.Store = SelectedStore;
            CartItems.Add(cartItem);
            Debug.WriteLine("Item Added to cart");
        }

        private void AddPriceForStore(string barcode)
        {
            //search for product
            var itemData = _itemIO.GetItemDataByBarcode(barcode);
            //Initiate adding new price data for selected store
            var priceArgs = new AddPriceForStoreArgs()
            {
                 Barcode = barcode,
                 Description = itemData.Description,
                 CurrentStore = SelectedStore,
                 ItemTaxId = itemData.TaxId,
                 ItemCatId = itemData.CategoryId,
                 ItemSubCatId = itemData.SubCategoryId,
                 ItemUnitId = itemData.UnitId
            };
            InitiateAddPriceData?.Invoke(this, priceArgs);
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
