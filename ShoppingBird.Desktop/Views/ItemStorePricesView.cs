using DevExpress.XtraEditors;
using ShoppingBird.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

    }
}