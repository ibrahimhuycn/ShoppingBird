using ShoppingBird.Desktop.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingBird.Desktop.Views
{
    public partial class TransactionHistoryView : DevExpress.XtraEditors.XtraForm
    {
        private readonly ITransactionHistoryViewModel _viewModel;

        public TransactionHistoryView(ITransactionHistoryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBinding();
            KeyUp += TransactionHistoryView_KeyUp;
            simpleButtonFetchTransactionHistory.Click += SimulateF2KeyUp;
        }

        private void SimulateF2KeyUp(object sender, EventArgs e)
        {
            TransactionHistoryView_KeyUp(sender, new KeyEventArgs(Keys.F2));
            _viewModel.CalculateCurrentTotal();
        }

        private async void TransactionHistoryView_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                await FetchTransactionHistoryAsync(e.KeyCode);
            }
            catch (Exception ex)
            {
                Helpers.NotificationHelper.ShowMessage(ex, "Cannot Load Transaction History");
            }
        }

        private async Task FetchTransactionHistoryAsync(Keys keyCode)
        {
            await _viewModel.LoadTransactionHistoryAsync();
        }

        private void InitializeBinding()
        {
            //gridControlTransactionHistory
            gridControlTransactionHistory.DataSource = _viewModel.TransactionHistory;

            //Start date
            dateEditStartDate.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.StartDate),
                false, DataSourceUpdateMode.OnPropertyChanged));
            //End date
            dateEditEndDate.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.EndDate),
                false, DataSourceUpdateMode.OnPropertyChanged));
            //checkEditGetCompleteTransactionHistory
            checkEditGetCompleteTransactionHistory.DataBindings.Add(new Binding("Checked", _viewModel,
                nameof(_viewModel.IsGetCompleteTransactionHistory), false, DataSourceUpdateMode.OnPropertyChanged));

            labelControlTotal.DataBindings.Add(new Binding("Text",_viewModel, nameof(_viewModel.SumOfTotal),
                false, DataSourceUpdateMode.OnPropertyChanged));
        }
    }
}