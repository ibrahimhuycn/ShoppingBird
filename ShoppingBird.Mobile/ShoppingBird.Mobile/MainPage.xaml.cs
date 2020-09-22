using Plugin.Toast;
using ShoppingBird.Mobile.Models;
using Syncfusion.XForms.ComboBox;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingBird.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            _viewModel.DisplayAlert += this.DisplayViewModelAlert;
            SearchBar.Unfocused += ReForcusSearchBar;
            SearchBar.SelectionChanged += SearchBar_OnSearch;
            SearchBar.Completed += SearchBar_OnSearch;
            _viewModel.CheckForSavedData?.Invoke(this, new System.Runtime.CompilerServices.AsyncVoidMethodBuilder());
            _viewModel.ItemNotFound += OnItemNotFound;
            _viewModel.DisplayPrompt += this.DisplayPrompt;
            _viewModel.InitiateAddPriceData += this.OnInitiatePriceData;
            _viewModel.InitiateEditSelectedItem += _viewModel_InitiateEditSelectedItem;
            _viewModel.DisplayToast += _viewModel_DisplayToast;
        }

        private async void _viewModel_InitiateEditSelectedItem(object sender, EditItemArgs e)
        {
            await LoadItemAddEditPageAsync(e); 
        }

        /// <summary>
        /// Display a toast notification
        /// </summary>
        /// <param name="e">Toastmodel with required data</param>
        private void _viewModel_DisplayToast(object sender, ToastModel e)
        {

            switch (e.Type)
            {
                case ToastModel.MessageType.Normal:
                    CrossToastPopUp.Current.ShowToastMessage(e.Message, e.ToastLength);
                    break;
                case ToastModel.MessageType.Success:
                    CrossToastPopUp.Current.ShowToastSuccess(e.Message, e.ToastLength);
                    break;
                case ToastModel.MessageType.Warning:
                    CrossToastPopUp.Current.ShowToastWarning(e.Message, e.ToastLength);
                    break;
                case ToastModel.MessageType.Error:
                    CrossToastPopUp.Current.ShowToastError(e.Message, e.ToastLength);
                    break;
                default:
                    break;
            }
        }

        private async void OnInitiatePriceData(object sender, AddPriceForStoreArgs e)
        {
            await LoadItemAddEditPageAsync(e);
        }

        private async Task LoadItemAddEditPageAsync(dynamic e)
        {
            SearchBar.Unfocused -= ReForcusSearchBar;
            var addItemPage = new AddItemPage(e);
            addItemPage.Disappearing += AddItemPage_Disappearing;
            addItemPage.UpdateSuccessful += AddItemPage_UpdateSuccessful;
            await Navigation.PushModalAsync(addItemPage);
        }

        private void AddItemPage_UpdateSuccessful(object sender, EditItemArgs e)
        {
            _viewModel.UpdateUiOnItemUpdate(e);
        }

        private void SearchBar_OnSearch(object sender, EventArgs e)
        {
            _viewModel.ExecuteSearchCommand.Execute(this);
            SearchBar.Focus();
        }

        private async void OnItemNotFound(object sender, ItemNotFoundArgs e)
        {
            var response = await DisplayAlert("Item not found", "Cannot find the item you are looking for.., do you want to add the item?", "Yes", "No");
            if (response)
            {
                await LoadItemAddEditPageAsync(e);
            }
            else
            {
                _viewModel.SelectedProduct = null;
            }
        }

        /// <summary>
        /// Onclosing the add item page... clears the search box and get it on continuous focus
        /// </summary>
        private void AddItemPage_Disappearing(object sender, EventArgs e)
        {
            SearchBar.Focus();
            _viewModel.SelectedProduct = null;
            SearchBar.Unfocused += ReForcusSearchBar;
        }

        private void ReForcusSearchBar(object sender, FocusEventArgs e)
        {
            SearchBar.Focus();
            System.Diagnostics.Debug.WriteLine("search bar focused");
        }

        private async void DisplayViewModelAlert(object sender, string e)
        {
            await DisplayAlert("Required!", e, "OK");
        }

        private async void DisplayPrompt(object sender, PromptModel e)
        {
            var result = await DisplayPromptAsync(e.Header, e.Message,"OK", "Cancel");
            var IsInvoiceIdValid = int.TryParse(result, out int invoiceId);

            if (!IsInvoiceIdValid)
            {
                await DisplayAlert("Invalid", "Invoice Id needs to be an integer.", "OK");
                return;
            }

            _viewModel.InvoiceId = invoiceId;
            _viewModel.CheckOut();
        }
    }
}
