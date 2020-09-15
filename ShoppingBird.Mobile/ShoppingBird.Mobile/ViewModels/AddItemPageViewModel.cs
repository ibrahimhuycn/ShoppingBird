using ShoppingBird.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
namespace ShoppingBird.Mobile.ViewModels
{
    public class AddItemPageViewModel : BindableBase
    {
        private string _storeName;
        private string _barcode;
        private StoreModel _store;
        private string _description;
        private double? _price;

        public ICommand SaveItemCommand { get; }

        public AddItemPageViewModel()
        {
            TaxList = new List<TaxModel>();
            CategoryList = new List<CategoryModel>();
            UnitList = new List<UnitModel>();
            InitializeDemoData();

            SaveItemCommand = new Command(SaveItem);
            PropertyChanged += AddItemPageViewModel_PropertyChanged;
        }

        private void AddItemPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SaveItemCommand.CanExecute(this);
        }

        private void InitializeDemoData()
        {
            //setup demo tax objects
            var gst = new TaxModel() { Id = 1, Description = "GST 6 %", Percent = 0.06 };
            var noTax = new TaxModel() { Id = 2, Description = "No Tax", Percent = 0 };

            TaxList.Add(gst);
            TaxList.Add(noTax);
            //setup demo catagories
            var fruits = new CategoryModel() { Id = 1, Category = "Fruits" };
            var canned = new CategoryModel() { Id = 1, Category = "Canned Foods" };
            CategoryList.Add(fruits);
            CategoryList.Add(canned);
            //setup demo units
            var grams = new UnitModel() { Id = 1, Unit = "g", Description = "Gram" };
            var kiloGrams = new UnitModel() { Id = 2, Unit = "Kg", Description = "Kilogram" };
            UnitList.Add(grams);
            UnitList.Add(kiloGrams);

        }

        public StoreModel Store
        {
            get => _store; set
            {
                _store = value;
                this.StoreName = _store.Name;
            }
        }
        public string StoreName
        {
            get => _storeName; set
            {
                if (_storeName == value) return;
                _storeName = value;
                NotifyPropertyChanged();
            }
        }
        public string Barcode
        {
            get => _barcode; set
            {
                if (_barcode == value) return;
                _barcode = value;
                NotifyPropertyChanged();
            }
        }

        public string Description
        {
            get => _description; set
            {
                if (_description == value) return;
                _description = value;
                NotifyPropertyChanged();
            }
        }
        public double? Price
        {
            get => _price; set
            {
                if (_price == value) return;
                _price = value;
                NotifyPropertyChanged();
            }
        }
        public List<TaxModel> TaxList { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        public List<UnitModel> UnitList { get; set; }

        public TaxModel SelectedTax { get; set; }
        public CategoryModel SelectedCategory { get; set; }
        public CategoryModel SelectedSubCategory { get; set; }
        public UnitModel SelectedUnit { get; set; }

        //Saves the current item
        void SaveItem()
        {
            if(IsOkToSave())
            {
                //save
            }
            else
            {
                throw new Exception("Cannot save. All parameters not provided.");
            }
        }

        private bool IsOkToSave()
        {
            if (string.IsNullOrEmpty(Description)) return false;
            if (Price is null || Price == 0) return false;
            if (SelectedTax is null) return false;
            if (SelectedCategory is null) return false;
            if (SelectedSubCategory is null) return false;
            if (SelectedUnit is null) return false;
            return true;
        }


    }
}
