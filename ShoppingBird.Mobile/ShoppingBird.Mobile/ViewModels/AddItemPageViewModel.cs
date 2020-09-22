using ShoppingBird.Fly;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using ShoppingBird.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
namespace ShoppingBird.Mobile.ViewModels
{
    public class AddItemPageViewModel : BindableBase
    {
        private readonly ITaxIO _taxIO;
        private readonly ICategoriesIO _categoriesIO;
        private readonly IUnitsIO _unitsIO;
        private readonly IItemIO _itemIO;
        private string _storeName;
        private string _barcode;
        private StoreModel _store;
        private string _description;
        private double? _price;
        private TaxModel _selectedTax;
        private CategoryModel _selectedCategory;
        private CategoryModel _selectedSubCategory;
        private UnitModel _selectedUnit;
        private string _pageTitle;

        public ItemActionMode _actionMode;
        public event EventHandler<ToastModel> DisplayToast;
        public event EventHandler<ItemUpdateModel> ItemUpdateSuccessful;
        public ICommand SaveItemCommand { get; }

        public AddItemPageViewModel()
        {
            TaxList = new List<TaxModel>();
            CategoryList = new List<CategoryModel>();
            UnitList = new List<UnitModel>();
            _taxIO = new TaxIO();
            _categoriesIO = new CategoriesIO();
            _unitsIO = new UnitsIO();
            _itemIO = new ItemIO();

            //InitializeDemoData();
            LoadStaticData();

            SaveItemCommand = new Command(SaveItem);
            PropertyChanged += AddItemPageViewModel_PropertyChanged;
        }

        private void LoadStaticData()
        {
            try
            {
                //get Tax list
                var taxList = _taxIO.GetAllTax();
                //get Categories list
                var categoryList = _categoriesIO.LoadAll();
                //get units list
                var unitList = _unitsIO.LoadAll();

                InitializeStaticData(new dynamic[] { taxList, categoryList, unitList });
            }
            catch (Exception)
            {

                throw;
            }


        }

        internal void InitializeForItemEditing(EditItemArgs args)
        {
            InitializeParamsExceptPrice(args);
            Price = args.RetailPrice;
        }

        /// <summary>
        /// Initializes static lists
        /// </summary>
        /// <param name="staticDataArray">dynamic array with tax, category and unit list at index 0,1 and 2</param>
        private void InitializeStaticData(dynamic[] staticDataArray)
        {
            for (int i = 0; i < staticDataArray.Length; i++)
            {
                switch (i)
                {
                    case 0: //tax list init
                        TaxList.Clear();
                        foreach (Fly.Models.Tax item in staticDataArray[i])
                        {
                            TaxList.Add(new TaxModel()
                            {
                                Id = item.Id,
                                Description = item.Description,
                                Percent = double.Parse(item.Rate.ToString())
                            });
                        }
                        break;
                    case 1: // Category list init
                        CategoryList.Clear();
                        foreach (Fly.Models.ItemCategory item in staticDataArray[i])
                        {
                            CategoryList.Add(new CategoryModel()
                            {
                                Id = item.Id,
                                Category = item.Category
                            });
                        }
                        break;
                    case 2: // Unit List init
                        UnitList.Clear();
                        foreach (Fly.Models.Units item in staticDataArray[i])
                        {
                            UnitList.Add(new UnitModel()
                            {
                                Id = item.Id,
                                Unit = item.Unit,
                                Description = item.Description
                            });
                        }
                        break;
                    default:
                        throw new Exception("Unknown static list for initialization.");
                }
            }
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

        internal void InitializeForAddingPrice(AddPriceForStoreArgs args)
        {
            InitializeParamsExceptPrice(args);
        }

        private void InitializeParamsExceptPrice(dynamic args)
        {
            Description = args.Description;
            Barcode = args.Barcode;
            Store = args.CurrentStore;
            SelectedTax = TaxList.Find((x) => x.Id == args.ItemTaxId);
            SelectedCategory = CategoryList.Find((x) => x.Id == args.ItemCatId);
            SelectedSubCategory = CategoryList.Find((x) => x.Id == args.ItemSubCatId);
            SelectedUnit = UnitList.Find((x) => x.Id == args.ItemUnitId);
        }

        public string PageTitle
        {
            get => _pageTitle; set
            {
                if (_pageTitle == value) return;
                _pageTitle = value;
                NotifyPropertyChanged();
            }
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
        public TaxModel SelectedTax
        {
            get => _selectedTax; set
            {
                if (_selectedTax == value) return;
                _selectedTax = value;
                NotifyPropertyChanged();
            }
        }
        public CategoryModel SelectedCategory
        {
            get => _selectedCategory; set
            {
                if (_selectedCategory == value) return;
                _selectedCategory = value;
                NotifyPropertyChanged();
            }
        }
        public CategoryModel SelectedSubCategory
        {
            get => _selectedSubCategory; set
            {
                if (_selectedSubCategory == value) return;
                _selectedSubCategory = value;
                NotifyPropertyChanged();
            }
        }
        public UnitModel SelectedUnit
        {
            get => _selectedUnit; set
            {
                if (_selectedUnit == value) return;
                _selectedUnit = value;
                NotifyPropertyChanged();
            }
        }

        //Saves the current item
        void SaveItem()
        {
            if (IsOkToSave())
            {
                var saveInsertItem = new Item()
                {
                    Category = new ItemCategory() { Id = SelectedCategory.Id, Category = SelectedCategory.Category },
                    SubCategory = new ItemCategory() { Id = SelectedSubCategory.Id, Category = SelectedSubCategory.Category },
                    Description = Description
                };

                var priceData = new ItemPriceData()
                {
                    Barcode = Barcode,
                    Item = saveInsertItem,
                    RetailPrice = decimal.Parse(Price.ToString()),
                    Store = Store,
                    Tax = new Tax()
                    {
                        Id = SelectedTax.Id,
                        Description = SelectedTax.Description,
                        Rate = decimal.Parse(SelectedTax.Percent.ToString())
                    },
                    Unit = new Units()
                    {
                        Id = SelectedUnit.Id,
                        Unit = SelectedUnit.Unit,
                        Description = SelectedUnit.Description
                    }
                };

                try
                {
                    switch (_actionMode)
                    {
                        case ItemActionMode.AddNewItem:
                        case ItemActionMode.AddPriceForStore:
                            ExecuteSave(priceData, saveInsertItem);
                            break;
                        case ItemActionMode.EditItem:
                            ExecuteUpdates(priceData, saveInsertItem);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    DisplayToast?.Invoke(this, new ToastModel()
                    {
                        Message = $"Error saving item record!\n\n {ex.Message}",
                        Type = ToastModel.MessageType.Error,
                        ToastLength = Plugin.Toast.Abstractions.ToastLength.Long
                    });
                }
            }
            else
            {
                DisplayToast?.Invoke(this, new ToastModel()
                {
                    Message = "Please complete all required fields",
                    Type = ToastModel.MessageType.Error,
                    ToastLength = Plugin.Toast.Abstractions.ToastLength.Long
                });
            }
        }

        private void ExecuteUpdates(ItemPriceData priceData, Item saveInsertItem)
        {
            var update = new ItemUpdateModel()
            {
                Barcode = priceData.Barcode,
                Description = saveInsertItem.Description,
                ItemId = saveInsertItem.Id,
                StoreId = priceData.Store.Id,
                RetailPrice = priceData.RetailPrice,
                TaxId = priceData.Tax.Id,
                UnitId = priceData.Unit.Id,
                CategoryId = saveInsertItem.Category.Id,
                SubCategoryId = saveInsertItem.SubCategory.Id
            };
            try
            {
                _itemIO.UpdateItem(update);
                ItemUpdateSuccessful?.Invoke(this, update);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ExecuteSave(ItemPriceData priceData, Item saveInsertItem)
        {
            if (_itemIO.SaveItem(new ItemInsertDataArgs(saveInsertItem, priceData)) == 0)
            {
                DisplayToast?.Invoke(this, new ToastModel()
                {
                    Message = "Item saved successfully.",
                    Type = ToastModel.MessageType.Success,
                    ToastLength = Plugin.Toast.Abstractions.ToastLength.Long
                });
            }
            else
            {
                DisplayToast?.Invoke(this, new ToastModel()
                {
                    Message = "Something unexpected happened! Not sure that the item was saved!",
                    Type = ToastModel.MessageType.Warning,
                    ToastLength = Plugin.Toast.Abstractions.ToastLength.Long
                });
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
