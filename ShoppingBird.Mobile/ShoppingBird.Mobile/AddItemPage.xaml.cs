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
        private readonly ItemNotFoundArgs _args;

        public AddItemPage(ItemNotFoundArgs args)
        {
            InitializeComponent();
            _args = args;
            InitializeDisplayData();
            ButtonCancel.Clicked += ButtonCancel_Clicked;
        }

        private void InitializeDisplayData()
        {
            _viewModel.Store = _args.SelectedStore;
            _viewModel.Barcode = _args.Barcode;
        }

        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}