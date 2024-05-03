using ShoopingBird.Maui.ViewModel;

namespace ShoopingBird.Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }
    }

}
