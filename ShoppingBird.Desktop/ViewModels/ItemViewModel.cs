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
    public class ItemViewModel : NotifyBase, IItemViewModel
    {
        #region Private Fileds
        private readonly IMapper _mapper;
        private readonly IItemIO _itemIO;
        private ItemListAllModel _selectedItem;
        private int? _selectedItemId;
        private string _selectedItemDescription;

        #endregion
        private event EventHandler OnInitialize;
        #region Constructor
        public ItemViewModel(IMapper mapper, IItemIO itemIO)
        {
            _mapper = mapper;
            _itemIO = itemIO;

            AllItems = new BindingList<ItemListAllModel>();
            SelectedItem = new ItemListAllModel();

            OnInitialize += ItemViewModel_OnInitialize;
            OnInitialize?.Invoke(this, EventArgs.Empty);
        }

        #endregion
        #region Public Properties
        public BindingList<ItemListAllModel> AllItems { get; set; }
        public ItemListAllModel SelectedItem
        {
            get => _selectedItem; set
            {
                _selectedItem = value;
                if (value != null)
                {
                    SelectedItemId = value.Id;
                    SelectedItemDescription = value.Item;
                }
                else
                {
                    SelectedItemId = null;
                    SelectedItemDescription = null;
                }

            }
        }
        public int? SelectedItemId
        {
            get => _selectedItemId; set
            {
                _selectedItemId = value;
                OnPropertyChanged();
            }
        }
        public string SelectedItemDescription
        {
            get => _selectedItemDescription; set
            {
                _selectedItemDescription = value;
                OnPropertyChanged();
            }
        }

        #endregion
        #region Public Methods

        #endregion
        #region Private Methods
        private async void ItemViewModel_OnInitialize(object sender, EventArgs e)
        {
            await LoadAllItemsAsync();
        }

        private async Task LoadAllItemsAsync()
        {
            var items = await _itemIO.GetAllItemsWithDescriptionAsync();
            var mapped = _mapper.Map<List<ItemListAllModel>>(items);
            foreach (var item in mapped)
            {
                AllItems.Add(item);
            }
        }

        #endregion
    }
}
