using _1TheDebtBook.ViewModels;
using Microsoft.Extensions.Logging;
using _1TheDebtBook.Pages;

namespace _1TheDebtBook
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
            // adding view models
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<AddViewModel>();
            // adding pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<AddPage>();
#endif      

            var app = builder.Build();
            return app;
        }
    }
}
