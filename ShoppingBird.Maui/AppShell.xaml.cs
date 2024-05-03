using ShoppingBird.Maui.Views;

namespace ShoppingBird.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
            Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
            Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
            Routing.RegisterRoute(nameof(StorePricesPage), typeof(StorePricesPage));
            Routing.RegisterRoute(nameof(StoresPage), typeof(StoresPage));

        }
    }
}
