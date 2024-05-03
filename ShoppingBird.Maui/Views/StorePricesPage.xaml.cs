using ShoppingBird.Maui.ViewModels;

namespace ShoppingBird.Maui.Views;

public partial class StorePricesPage : ContentPage
{
	public StorePricesPage(StorePricesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

    }
}