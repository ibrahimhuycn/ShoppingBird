using AutoMapper;
using Shopping.Desktop.Helpers;
using Shopping.Desktop.Models;
using Shopping.Desktop.Transations;
using ShoppingBird.Fly.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Shopping.Desktop.ViewModels
{
    public class CartViewModel : NotifyBase, ICartViewModel
    {
        private readonly IItemIO _itemIO;
        private readonly IMapper _mapper;
        private int _selectedItemId;
        private int _selectedStoreId;

        public CartViewModel(IItemIO itemIO, IMapper mapper)
        {
            _itemIO = itemIO;
            _mapper = mapper;
            ItemSearchDatasource = new List<ItemListAllModel>();

            Initialize();
        }


        public List<ItemListAllModel> ItemSearchDatasource { get; set; }
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

        #region Public Methods
        public void AddSelectedItemToCart()
        {
            if (SelectedItemId <= 0) { throw new Exception(GlobalStrings.CartView_NoItemSelected); }
            if (SelectedStoreId <= 0) { throw new Exception(GlobalStrings.CartView_NoStoreSelected); }

            var item = _itemIO.GetItemByItemIdAndStoreId(SelectedItemId, SelectedStoreId);

        }
        #endregion


        #region Private Methods
        private void Initialize()
        {
            LoadItemsSearchData();
        }

        private void LoadItemsSearchData()
        {
            var data = _itemIO.GetAllItemDescriptions();
            var mapped = _mapper.Map<List<ItemListAllModel>>(data);
            ItemSearchDatasource.AddRange(mapped);
        }
        #endregion

    }
}
