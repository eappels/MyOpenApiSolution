using Microsoft.Extensions.Logging;
using MyOpenApiMauiClient.Services;
using MyOpenApiMauiClient.Services.Interfaces;
using MyOpenApiMauiClient.ViewModels;
using MyOpenApiMauiClient.Views;

namespace MyOpenApiMauiClient;
public static class MauiProgram
{

    public static MauiApp CreateMauiApp()
        => MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureFonts(
                fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }
            )
            .Register()
            .Build();


    public static MauiAppBuilder Register(this MauiAppBuilder mauiAppBuilder)
    {
#if DEBUG
        mauiAppBuilder.Logging.AddDebug();
#endif

        mauiAppBuilder.Services.AddSingleton<IOpenApiConsumerService, OpenApiConsumerService>();

        mauiAppBuilder.Services.AddSingleton<MovieListViewModel>();
        mauiAppBuilder.Services.AddTransient<MovieListView>();

        return mauiAppBuilder;
    }
}
