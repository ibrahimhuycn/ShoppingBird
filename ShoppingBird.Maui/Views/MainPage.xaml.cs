using ShopingBird.Maui.ViewModel;

namespace ShoppingBird.Maui
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

    }

}
