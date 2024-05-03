using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShoppingBird.Maui.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Services.Store;

namespace ShopingBird.Maui.ViewModel;

public partial class MainViewModel: ObservableObject
{
    [ObservableProperty]
    int myProperty;

    [RelayCommand]
    public async Task GotoCartView() => await Shell.Current.GoToAsync(nameof(CartPage));

    [RelayCommand]
    public async Task GotoStoresView() => await Shell.Current.GoToAsync(nameof(StoresPage));

    [RelayCommand]
    public async Task GotoItemsView() => await Shell.Current.GoToAsync(nameof(ItemsPage));

    [RelayCommand]
    public async Task GotoHistoryView() => await Shell.Current.GoToAsync(nameof(HistoryPage));

    [RelayCommand]
    public async Task GotoStorePricesView() => await Shell.Current.GoToAsync(nameof(StorePricesPage));

}
