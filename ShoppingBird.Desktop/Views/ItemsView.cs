using ShoppingBird.Desktop.Models;
using ShoppingBird.Desktop.ViewModels;
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