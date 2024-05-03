using Microsoft.Extensions.Logging;
using ShopingBird.Maui.ViewModel;
using ShoppingBird.Maui.ViewModels;
using ShoppingBird.Maui.Views;

namespace ShoppingBird.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<CartPage>();
            builder.Services.AddTransient<CartViewModel>();
            builder.Services.AddTransient<HistoryPage>();
            builder.Services.AddTransient<HistoryViewModel>();
            builder.Services.AddTransient<ItemsPage>();
            builder.Services.AddTransient<ItemsViewModel>();
            builder.Services.AddTransient<StorePricesPage>();
            builder.Services.AddTransient<StorePricesViewModel>();
            builder.Services.AddTransient<StoresPage>();
            builder.Services.AddTransient<StoresViewModel>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");


                    fonts.AddFont("Ubuntu-Italic.ttf", "UbuntuItalic");

                    fonts.AddFont("Ubuntu-Light.ttf", "UbuntuLight");
                    fonts.AddFont("Ubuntu-LightItalic.ttf", "UbuntuLightItalic");

                    fonts.AddFont("Ubuntu-Medium.ttf", "UbuntuMedium");
                    fonts.AddFont("Ubuntu-MediumItalic.ttf", "UbuntuMediumItalic");

                    fonts.AddFont("Ubuntu-Regular.ttf", "UbuntuRegular");

                    fonts.AddFont("Ubuntu-Bold.ttf", "UbuntuBold");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
