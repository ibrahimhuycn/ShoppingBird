using ShopingBird.Maui.ViewModel;

namespace ShoppingBird.Maui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

    }

}
