using Microsoft.Extensions.Logging;
using PokemonMauiApp.Services;
using PokemonMauiApp.View;
using PokemonMauiApp.ViewModel;

namespace PokemonMauiApp
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
#endif
            
            //platform api
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<IMap>(Map.Default);

            //services
            builder.Services.AddSingleton<PokemonService>();

            //view models
            builder.Services.AddSingleton<PokemonsViewModel>();
            builder.Services.AddTransient<PokemonDetailsViewModel>();

            //pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<DetailsPage>();

            return builder.Build();
        }
    }
}