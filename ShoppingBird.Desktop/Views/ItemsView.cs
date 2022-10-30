using ShoppingBird.Desktop.Models;
using ShoppingBird.Desktop.ViewModels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingBird.Desktop.Views
{
    public partial class ItemsView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IItemViewModel _viewModel;

        public ItemsView(IItemViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBinding();

            gridViewItem.FocusedRowChanged += GridViewItem_FocusedRowChanged;
            simpleButtonInsertItem.Click += SimpleButtonInsertItem_Click;
            simpleButtonSaveItem.Click += SimpleButtonSaveItem_ClickAsync;
        }

        private async void SimpleButtonSaveItem_ClickAsync(object sender, System.EventArgs e)
        {
            await _viewModel.InsertUpdateItemAsync();
        }

        private void SimpleButtonInsertItem_Click(object sender, System.EventArgs e)
        {
            _viewModel.SetInsertMode();
        }

        private void GridViewItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var selectedItem = (ItemListAllModel)gridViewItem.GetRow(e.FocusedRowHandle);
            _viewModel.SelectedItemId = selectedItem.Id;
            _viewModel.SelectedItemDescription = selectedItem.Item;
        }

        private void InitializeBinding()
        {
            gridControlItems.DataSource = _viewModel.AllItems;
            textEditItemId.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.SelectedItemId),
                false, DataSourceUpdateMode.OnPropertyChanged));
            textEditItemName.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.SelectedItemDescription),
                false, DataSourceUpdateMode.OnPropertyChanged));
        }
    }
}