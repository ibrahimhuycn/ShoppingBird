using Microsoft.Extensions.Logging;
using ShoopingBird.Maui.ViewModel;

namespace ShoopingBird.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddTransient<MainViewModel>();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    //fonts.AddFont("Ubuntu-Light.ttf", "UbuntuLight");
                    //fonts.AddFont("Ubuntu-LightItalic.ttf", "UbuntuLightItalic");
                    //fonts.AddFont("Ubuntu-Medium.ttf", "UbuntuMedium");
                    //fonts.AddFont("Ubuntu-MediumItalic.ttf", "UbuntuMediumItalic");
                    //fonts.AddFont("Ubuntu-Regular.ttf", "UbuntuRegular");
                    //fonts.AddFont("Ubuntu-Bold.ttf", "UbuntuBold");
                    //fonts.AddFont("Ubuntu-BoldItalic.ttf", "UbuntuBoldItalic");
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
