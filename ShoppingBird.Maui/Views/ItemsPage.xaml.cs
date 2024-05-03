using ShoppingBird.Maui.ViewModels;

namespace ShoppingBird.Maui.Views;

public partial class ItemsPage : ContentPage
{
	public ItemsPage(ItemsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

    }
}