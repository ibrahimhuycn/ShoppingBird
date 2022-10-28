using ShoppingBird.Desktop.Models;
using ShoppingBird.Desktop.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingBird.Desktop.Views
{
    public partial class StoreView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IStoreViewModel _viewModel;

        public StoreView(IStoreViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBinding();
            gridViewStore.FocusedRowChanged += GridViewStore_FocusedRowChanged;
            simpleButtonInsertStore.Click += SimpleButtonInsertStore_Click;
            simpleButtonSaveStore.Click += SimpleButtonSaveStore_Click;
            KeyUp += StoreView_KeyUp;
        }

        private async void StoreView_KeyUp(object sender, KeyEventArgs e)
        {
            await SaveStoreAsync(e.KeyCode);
            SetStoreInsertMode(e.KeyCode);
        }

        private void SetStoreInsertMode(Keys keyCode)
        {
            if (keyCode != Keys.Insert) { return; }
            _viewModel.SetStoreInsertMode();
        }

        private async Task SaveStoreAsync(Keys keyCode)
        {
            if (keyCode != Keys.F6) { return; }
            try
            {
                await _viewModel.SaveStoreAsync();
            }
            catch (Exception ex)
            {
                Helpers.NotificationHelper.ShowMessage(ex, "Cannot Save Store");
            }
        }

        private void SimpleButtonInsertStore_Click(object sender, EventArgs e)
        {
            SetStoreInsertMode(Keys.Insert);
        }
        private async void SimpleButtonSaveStore_Click(object sender, EventArgs e)
        {
            await SaveStoreAsync(Keys.F6);
        }

        private void GridViewStore_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var selectedStore = (StoreModel)gridViewStore.GetRow(e.FocusedRowHandle);
            _viewModel.SelectedStoreId = selectedStore.Id;
            _viewModel.SelectedStoreName = selectedStore.Name;
        }

        private void InitializeBinding()
        {
            //gridControlStores
            gridControlStores.DataSource = _viewModel.AllStores;

            textEditStoreId.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.SelectedStoreId),
                false, DataSourceUpdateMode.OnPropertyChanged));
            textEditStoreName.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.SelectedStoreName),
                false, DataSourceUpdateMode.OnPropertyChanged));
        }
    }
}