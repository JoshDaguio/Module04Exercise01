using Microsoft.Extensions.Logging;
using Module03Exercise01.View;
using Module03Exercise01.Services;

namespace Module03Exercise01
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

            //Service
            builder.Services.AddSingleton<IMyService, MyService>();
            //ContentPage
            builder.Services.AddTransient<LoginPage>        ();

    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
