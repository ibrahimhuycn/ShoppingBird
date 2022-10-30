using DevExpress.XtraEditors;
using ShoppingBird.Desktop.Exceptions;
using ShoppingBird.Desktop.Helpers;
using ShoppingBird.Desktop.Models;
using ShoppingBird.Desktop.Translations;
using ShoppingBird.Desktop.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingBird.Desktop.Views
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
            gridViewCart.CellValueChanged += CalculateTotalCartPrice;
            simpleButtonSetCartLabel.Click += SimpleButtonSetCartLabel_Click;
            simpleButtonCheckout.Click += SimpleButtonCheckout_Click;
            simpleButtonClearCart.Click += SimpleButtonClearCart_Click;
        }

        private void SimpleButtonClearCart_Click(object sender, EventArgs e) => ClearCart(Keys.Delete);

        private void SimpleButtonCheckout_Click(object sender, EventArgs e) => CheckoutCurrentCart(Keys.F6);

        private void SimpleButtonSetCartLabel_Click(object sender, EventArgs e) => SetCartLabel(Keys.F8);

        private void CalculateTotalCartPrice
            (object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) => _viewModel.CalculateTotalCartAmount();

        private async void CartView_KeyUp(object sender, KeyEventArgs e)
        {
            await AddSelectedItemToCartAsync(e.KeyCode);
            SetCartLabel(e.KeyCode);
            CheckoutCurrentCart(e.KeyCode);
            ClearCart(e.KeyCode);
        }

        private void CheckoutCurrentCart(Keys keyCode)
        {
            if (keyCode == Keys.F6)
            {
                var invoiceNumber = XtraInputBox.Show("Please enter the invoice / bill number.", "Invoice Number Required", "");
                if (invoiceNumber == "") { XtraMessageBox.Show("Invoice number cannot be zero. Please try again."); return; }
                _viewModel.InvoiceNumber = invoiceNumber;
                _viewModel.SaveCurrentCart();
            }
        }

        private void SetCartLabel(Keys keyCode)
        {
            if (keyCode == Keys.F8)
            {
                var response = (string)XtraInputBox.Show(GlobalStrings.CartView_LabelRequest, GlobalStrings.CartView_LabelRequestHeader, null);
                if (string.IsNullOrEmpty(response)) { Text = "Shopping Cart"; return; }

                Text = $"Shopping Cart: {response}";
            }
        }
        private void ClearCart(Keys keyCode)
        {
            if (keyCode == Keys.Delete)
            {
                _viewModel.ClearCart();
            }
        }

        private async Task AddSelectedItemToCartAsync(Keys key)
        {
            try
            {
                if (lookUpEditSearch.IsEditorActive && key == Keys.F2)
                {
                    await _viewModel.AddSelectedItemToCart();
                    lookUpEditSearch.ClosePopup();
                }
            }
            catch (NoItemSelectedException ex)
            {
                NotificationHelper.ShowMessage(ex);
            }
            catch (NoStoreSelectedException ex)
            {
                NotificationHelper.ShowMessage(ex);
            }
            catch (CartItemNotFoundForStoreException)
            {
                var response = NotificationHelper.ShowMessageWithResult(GlobalStrings.CartView_ItemNotFoundForStore);
                //send a message to display item entry view depending on user response
            }
            catch (Exception ex)
            {
                NotificationHelper.ShowMessage(ex);
            }
        }
        private void InitilizeBinding()
        {
            //gridControlCart
            gridControlCart.DataSource = _viewModel.AllCartItems;
            //lookUpEditSearch
            lookUpEditSearch.Properties.DataSource = _viewModel.ItemSearchDatasource;
            lookUpEditSearch.Properties.ValueMember = nameof(ItemListAllModel.Id);
            lookUpEditSearch.Properties.DisplayMember = nameof(ItemListAllModel.Item);
            lookUpEditSearch.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedItemId),
                false, DataSourceUpdateMode.OnPropertyChanged));

            //lookUpEditStore
            lookUpEditStore.Properties.DataSource = _viewModel.AllStores;
            lookUpEditStore.Properties.DisplayMember = nameof(StoreModel.Name);
            lookUpEditStore.Properties.ValueMember = nameof(StoreModel.Id);
            lookUpEditStore.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedStoreId),
                false, DataSourceUpdateMode.OnPropertyChanged));

            //textEditAdjustmentAmount
            textEditAdjustmentAmount.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.AdjustmentAmount),
                false, DataSourceUpdateMode.OnPropertyChanged));
            //textEditTotalAmount
            textEditTotalAmount.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.TotalCartAmount),
                false, DataSourceUpdateMode.OnPropertyChanged));
        }
    }
}