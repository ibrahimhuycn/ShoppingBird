using Plugin.Toast;
using ShoppingBird.Fly.Models;
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
        public event EventHandler<EditItemArgs> UpdateSuccessful;

        private readonly ItemNotFoundArgs _itemNotFoundArgs;
        private readonly AddPriceForStoreArgs _addPriceArgs;
        private readonly EditItemArgs _editItemArgs;
        public AddItemPage(ItemNotFoundArgs args)
        {
            PreInitialization();
            _itemNotFoundArgs = args;
            InitializeDisplayData(ItemActionMode.AddNewItem);
        }

        public AddItemPage(AddPriceForStoreArgs args)
        {
            PreInitialization();
            _addPriceArgs = args;
            InitializeDisplayData(ItemActionMode.AddPriceForStore);
        }
        public AddItemPage(EditItemArgs args)
        {
            PreInitialization();
            _editItemArgs = args;
            InitializeDisplayData(ItemActionMode.EditItem);
        }

        private void PreInitialization() 
        {
            InitializeComponent();
            ButtonCancel.Clicked += ButtonCancel_Clicked;
            _viewModel.DisplayToast += _viewModel_DisplayToast;
            _viewModel.ItemUpdateSuccessful += _viewModel_ItemUpdateSuccessful;
        }

        private void _viewModel_ItemUpdateSuccessful(object sender, ItemUpdateModel e)
        {
            //show a meesage to indicate successful update
            _viewModel_DisplayToast(this, new ToastModel()
            {
                Message = "Item updated successfully.",
                ToastLength = Plugin.Toast.Abstractions.ToastLength.Long,
                Type = ToastModel.MessageType.Success
            });
            //update the UI
            UpdateSuccessful?.Invoke(this, _editItemArgs.SetUpdatedData(e));
            ButtonCancel_Clicked(this, EventArgs.Empty);

        }


        private void InitializeDisplayData(ItemActionMode initializeMode)
        {
            switch (initializeMode)
            {
                case ItemActionMode.AddNewItem:
                    _viewModel.Store = _itemNotFoundArgs.SelectedStore;
                    _viewModel.Barcode = _itemNotFoundArgs.Barcode;
                    _viewModel._actionMode = ItemActionMode.AddNewItem;
                    _viewModel.PageTitle = "Add New Item";
                    break;
                case ItemActionMode.AddPriceForStore:
                    _viewModel.InitializeForAddingPrice(_addPriceArgs);
                    _viewModel._actionMode = ItemActionMode.AddPriceForStore;
                    _viewModel.PageTitle = "Add Item Price";
                    break;
                case ItemActionMode.EditItem:
                    _viewModel.InitializeForItemEditing(_editItemArgs);
                    _viewModel._actionMode = ItemActionMode.EditItem;
                    _viewModel.PageTitle = "Edit Item";
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
    }
}