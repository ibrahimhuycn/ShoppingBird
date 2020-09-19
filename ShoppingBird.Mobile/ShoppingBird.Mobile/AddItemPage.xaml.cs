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
        }

        public AddItemPage(AddPriceForStoreArgs args)
        {
            InitializeComponent();
            _addPriceArgs = args;
            InitializeDisplayData(Mode.AddPriceForStore);
            ButtonCancel.Clicked += ButtonCancel_Clicked;
        }

        private void InitializeDisplayData(Mode initializeMode)
        {
            switch (initializeMode)
            {
                case Mode.AddNewItem:
                    _viewModel.Store = _itemNotFoundArgs.SelectedStore;
                    _viewModel.Barcode = _itemNotFoundArgs.Barcode;
                    break;
                case Mode.AddPriceForStore:
                    _viewModel.InitializeForAddingPrice(_addPriceArgs);
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