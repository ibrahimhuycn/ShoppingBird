using AutoMapper;
using ShoppingBird.Desktop.Helpers;
using ShoppingBird.Desktop.Models;
using ShoppingBird.Fly.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.ViewModels
{
    public class StoreViewModel : NotifyBase, IStoreViewModel
    {
        private readonly IStoreIO _storeIO;
        private readonly IMapper _mapper;
        private StoreModel _selectedStore;
        private int _selectedStoreId;
        private string _selectedStoreName;

        private event EventHandler OnInitialize;
        public StoreViewModel(IStoreIO storeIO, IMapper mapper)
        {
            AllStores = new BindingList<StoreModel>();
            _storeIO = storeIO;
            _mapper = mapper;

            OnInitialize += StoreViewModel_OnInitialize;
            OnInitialize?.Invoke(this, EventArgs.Empty);
        }


        public BindingList<StoreModel> AllStores { get; set; }
        public int SelectedStoreId
        {
            get => _selectedStoreId; set
            {
                _selectedStoreId = value;
                OnPropertyChanged();
            }
        }
        public string SelectedStoreName
        {
            get => _selectedStoreName; set
            {
                _selectedStoreName = value;
                OnPropertyChanged();
            }
        }

        #region Public Methods
        public async Task SaveStoreAsync()
        {
            if (string.IsNullOrEmpty(SelectedStoreName)) { throw new ArgumentException("Store name cannot be empty."); }
            if (SelectedStoreId < 0)
            {
                var inserted = await _storeIO.InsertStoreAsync(SelectedStoreName);
                var mapped = _mapper.Map<StoreModel>(inserted);
                DisplayInsertedOrUpdatedStore(mapped);
            }

            if (SelectedStoreId > 0)
            {
                var updated = await _storeIO.UpdateStoreAsync(new Fly.Models.StoreModel() { Id = SelectedStoreId, Name = SelectedStoreName});
                var mapped = _mapper.Map<StoreModel>(updated);
                DisplayInsertedOrUpdatedStore(mapped);
            }
        }


        public void SetStoreInsertMode()
        {
            SelectedStoreId = -1;
            SelectedStoreName = "";
        }
        #endregion

        #region Private Methods
        private void DisplayInsertedOrUpdatedStore(StoreModel storeModel)
        {
            SelectedStoreName = storeModel.Name;
            SelectedStoreId = storeModel.Id;

            var store = AllStores.FirstOrDefault(x=> x.Id == storeModel.Id);
            if (store is null) { AllStores.Add(storeModel); }
            else
            {
                store.Name = storeModel.Name;
            }

        }
        private async void StoreViewModel_OnInitialize(object sender, EventArgs e)
        {
            await LoadAllStoresAsync();
        }

        private async Task LoadAllStoresAsync()
        {
            try
            {
                AllStores.Clear();
                var stores = await _storeIO.GetAllStoresAsync();
                var mapped = _mapper.Map<List<StoreModel>>(stores);
                foreach (var item in mapped)
                {
                    AllStores.Add(item);
                }
            }
            catch (Exception ex)
            {
                Helpers.NotificationHelper.ShowMessage(ex, "Error loading stores");
            }
        }

        #endregion

    }
}
