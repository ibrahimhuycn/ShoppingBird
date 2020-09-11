using ShoppingBird.Fly;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingBird.Mobile.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private StoreModel _selectedStore;
        private string _selectedProduct;
        private readonly IStoreIO _storeIO;

        public EventHandler<string> DisplayAlert;
        public EventHandler BarcodeRead;
        private double _total;

        public MainPageViewModel()
        {
            this.AllStores = new List<StoreModel>();
            this.AllProducts = new List<Product>();
            this.CartItems = new ObservableCollection<CartItem>();
            this.Total = 0d;
            //load demo data
            LoadDemoData();
            _storeIO = new StoreIO();

            //act OnBarcodeRead
            BarcodeRead += OnBarcodeRead_ReCalculateTotal;
        }

        internal void RemoveItem(CartItem item)
        {
            if (item.Quantity > 1)
            {
                item.Quantity -= 1;
                return;
            }

            CartItems.Remove(item);

            //update total price display
            OnBarcodeRead_ReCalculateTotal(this, EventArgs.Empty);
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

        public ICommand OnSearch => new Command(() =>
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

            if (item is null)
            {
                DisplayAlert?.Invoke(this, "Cannot find the item you were looking for.");
                return;
            }

            //if item exists in cart, increase quantity...
            if (!IsItemInCart(barcode))
            {
                //otherwise add item to cart
                AddItemToCart(item);
            }

            SelectedProduct = "";
            //Up UI and calculations on reading barcode
            BarcodeRead?.Invoke(this, EventArgs.Empty);
        });

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

        /// <summary>
        /// Adds the passed in item to cart
        /// </summary>
        /// <param name="item"></param>
        private void AddItemToCart(Product item)
        {
            CartItems.Add(new CartItem().GetPartialInvoiceItem(item));
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
