using DevExpress.XtraEditors;
using Shopping.Desktop.Models;
using Shopping.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping.Desktop.Views
{
    public partial class CartView : DevExpress.XtraEditors.XtraForm
    {
        private readonly ICartViewModel _viewModel;

        public CartView(ICartViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitilizeBinding();
            KeyUp += CartView_KeyUp;
        }

        private void CartView_KeyUp(object sender, KeyEventArgs e)
        {
            if (lookUpEditSearch.IsEditorActive && e.KeyCode == Keys.Enter)
            {
                _viewModel.AddSelectedItemToCart();
            }
        }

        private void InitilizeBinding()
        {
            //lookUpEditSearch
            lookUpEditSearch.Properties.DataSource = _viewModel.ItemSearchDatasource;
            lookUpEditSearch.Properties.ValueMember = nameof(ItemListAllModel.Id);
            lookUpEditSearch.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedItemId),
                false, DataSourceUpdateMode.OnPropertyChanged));
        }
    }
}