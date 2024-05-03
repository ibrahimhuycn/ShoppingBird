using ShoppingBird.Maui.ViewModels;

namespace ShoppingBird.Maui.Views;

public partial class StoresPage : ContentPage
{
	public StoresPage(StoresViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}