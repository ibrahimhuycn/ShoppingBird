using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingBird.Maui.ViewModel;

public partial class MainViewModel: ObservableObject
{
    [ObservableProperty]
    int myProperty;

    [RelayCommand]
    public void ShopNow()
    {
        var a = 1;
        var b = 2;
        var c = a + b;
        Debug.WriteLine(c);
    }
}
