﻿using ShoppingBird.Mobile.Models;
using Syncfusion.XForms.ComboBox;
using System;
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
            //ButtonRemoveItem.Clicked += ButtonRemoveItem_Clicked;
            _viewModel.CheckForSavedData?.Invoke(this, new System.Runtime.CompilerServices.AsyncVoidMethodBuilder());
            _viewModel.ItemNotFound += OnItemNotFound;
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
                SearchBar.Unfocused -= ReForcusSearchBar;
                var addItemPage = new AddItemPage(e);
                addItemPage.Disappearing += AddItemPage_Disappearing;
                await Navigation.PushModalAsync(addItemPage);
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

        private void ButtonRemoveItem_Clicked(object sender, EventArgs e)
        {
            var item = (CartItem)CartItemsViewCollection.SelectedItem;
            if (item is null)
            {
                DisplayAlert("Remove Item", "Please select an item to remove.", "OK");
                return;
            }
            _viewModel.RemoveItem(item);
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
