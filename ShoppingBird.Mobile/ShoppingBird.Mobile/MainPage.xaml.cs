using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    }
}
