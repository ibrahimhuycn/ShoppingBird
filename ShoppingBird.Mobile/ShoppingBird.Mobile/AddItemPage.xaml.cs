using Plugin.Toast;
using ShoppingBird.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingBird.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        private readonly ItemNotFoundArgs _itemNotFoundArgs;
        private readonly AddPriceForStoreArgs _addPriceArgs;

        public AddItemPage(ItemNotFoundArgs args)
        {
            InitializeComponent();
            _itemNotFoundArgs = args;
            InitializeDisplayData(Mode.AddNewItem);
            ButtonCancel.Clicked += ButtonCancel_Clicked;
            _viewModel.DisplayToast += _viewModel_DisplayToast;

        }

        public AddItemPage(AddPriceForStoreArgs args)
        {
            InitializeComponent();
            _addPriceArgs = args;
            InitializeDisplayData(Mode.AddPriceForStore);
            ButtonCancel.Clicked += ButtonCancel_Clicked;
            _viewModel.DisplayToast += _viewModel_DisplayToast;

        }

        private void InitializeDisplayData(Mode initializeMode)
        {
            switch (initializeMode)
            {
                case Mode.AddNewItem:
                    _viewModel.Store = _itemNotFoundArgs.SelectedStore;
                    _viewModel.Barcode = _itemNotFoundArgs.Barcode;
                    _viewModel.PageTitle = "Add New Item";
                    break;
                case Mode.AddPriceForStore:
                    _viewModel.InitializeForAddingPrice(_addPriceArgs);
                    _viewModel.PageTitle = "Add Item Price";
                    break;
                default:
                    break;
            }

        }

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
        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private enum Mode
        {
            AddNewItem,
            AddPriceForStore
        }
    }
}