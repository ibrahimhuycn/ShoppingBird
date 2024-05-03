using ShoppingBird.Maui.ViewModels;

namespace ShoppingBird.Maui.Views;

public partial class HistoryPage : ContentPage
{
	public HistoryPage(HistoryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}