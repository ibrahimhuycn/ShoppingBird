using ShoppingBird.Maui.ViewModels;

namespace ShoppingBird.Maui.Views;

public partial class CartPage : ContentPage
{
	public CartPage(CartViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}