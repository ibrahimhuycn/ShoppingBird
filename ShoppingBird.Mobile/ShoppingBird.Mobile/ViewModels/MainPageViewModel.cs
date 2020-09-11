using ShoppingBird.Fly;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Mobile.Models;
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

        public MainPageViewModel()
        {
            this.AllStores = new List<StoreModel>();
            this.AllProducts = new List<Product>();
            this.CartItems = new ObservableCollection<CartItem>();

            //load demo data
            LoadDemoData();
            _storeIO = new StoreIO();
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
            var reader = new Product() { Id = 1, Item = "49024304012736 | Generic barcode reader" };
            AllProducts.Add(shampoo);
            AllProducts.Add(reader);

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

        public ICommand OnSearch => new Command(() =>
        {
            var barcode = SelectedProduct.Split('|')[0].Trim();
            var item = AllProducts.FindAll((x) => x.Item.Split('|')[0].Trim() == barcode).FirstOrDefault();
            CartItems.Add(new CartItem().GetPartialInvoiceItem(item));
            SelectedProduct = "";
        });
    }
}
