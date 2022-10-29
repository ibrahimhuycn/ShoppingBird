using ShoppingBird.Desktop.Models;
using ShoppingBird.Desktop.ViewModels;
using System;
using System.Windows.Forms;

namespace ShoppingBird.Desktop.Views
{
    public partial class ItemStorePricesView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IItemStorePricesViewModel _viewModel;

        public ItemStorePricesView(IItemStorePricesViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBinding();
            gridViewAllItems.FocusedRowChanged += GridViewAllItems_FocusedRowChanged;
            gridViewAllStores.FocusedRowChanged += GridViewAllStores_FocusedRowChanged;
            gridViewAllUnits.FocusedRowChanged += GridViewAllUnits_FocusedRowChanged;
            gridViewCurrentPrices.FocusedRowChanged += GridViewCurrentPrices_FocusedRowChanged;
            simpleButtonSave.Click += SimpleButtonSave_Click;
        }

        private async void SimpleButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.InsertOrUpdateStorePriceDataAsync();
            }
            catch (Exception ex)
            {
                Helpers.NotificationHelper.ShowMessage(ex);
            }
        }

        private void GridViewCurrentPrices_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var selectedItemStorePrice = (PriceListModel)gridViewCurrentPrices.GetRow(e.FocusedRowHandle);
            if (selectedItemStorePrice is null) { return; }

            _viewModel.SelectedPriceListModel = selectedItemStorePrice;
        }

        private void GridViewAllUnits_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var selectedUnit = (UnitsModel)gridViewAllUnits.GetRow(e.FocusedRowHandle);
            if (selectedUnit is null) { return; }

            _viewModel.SelectedUnitsModel = selectedUnit;
        }

        private void GridViewAllStores_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var selectedStore = (StoreModel)gridViewAllStores.GetRow(e.FocusedRowHandle);
            if (selectedStore is null) { return; }

            _viewModel.SelectedStoreModel = selectedStore;
        }

        private void GridViewAllItems_FocusedRowChanged
            (object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var selectedItem = (ItemListAllModel)gridViewAllItems.GetRow(e.FocusedRowHandle);
            if (selectedItem is null) { return; }

            _viewModel.SelectedItemModel = selectedItem;
        }

        private void InitializeBinding()
        {
            //gridControlAllItems
            gridControlAllItems.DataSource = _viewModel.AllItems;
            //gridControlAllStores
            gridControlAllStores.DataSource = _viewModel.AllStores;
            //gridControlAllUnits
            gridControlAllUnits.DataSource = _viewModel.AllUnits;
            //gridControlCurrentPrices
            gridControlCurrentPrices.DataSource = _viewModel.AllPricesForAllStores;

            //textEditBarcode
            textEditBarcode.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.SelectedBarcode),
                false, DataSourceUpdateMode.OnPropertyChanged));

            //textEditRetailPrice
            textEditRetailPrice.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.SelectedItemRetailPrice),
                false, DataSourceUpdateMode.OnPropertyChanged));

            //memoEditItemDescription
            memoEditItemDescription.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.SelectedItemDescription),
                false, DataSourceUpdateMode.OnPropertyChanged));

            //labelControlSelectedStore
            labelControlSelectedStore.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.SelectedStoreName)
                , false, DataSourceUpdateMode.OnPropertyChanged));

            //labelControlSelectedUnit
            labelControlSelectedUnit.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.SelectedUnit)
                , false, DataSourceUpdateMode.OnPropertyChanged));

            // toggleSwitchModeIndicator
            toggleSwitchModeIndicator.DataBindings.Add(new Binding("IsOn", _viewModel, nameof(_viewModel.IsAnExistingPriceSelected),
                false, DataSourceUpdateMode.OnPropertyChanged));
        }

    }
}