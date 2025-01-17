using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using Weather.Mobile.Services.Constracts;
using Weather.Mobile.Services.Implementations;
using Weather.Mobile.ViewModels;
using Weather.Mobile.Views;
using Weather.Services;

namespace Weather.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<GoogleSheetsService>(serviceProvider =>
            {
                // Đọc file JSON từ embedded resource
                var assembly = typeof(MauiProgram).Assembly;
                using var stream = assembly.GetManifestResourceStream("Weather.Mobile.Resources.credentials.json");
                using var reader = new StreamReader(stream!);
                string credentialsJson = reader.ReadToEnd();
                return new GoogleSheetsService(credentialsJson);
            });

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<IMap>(Map.Default);

            builder.Services.AddSingleton<ILoadingService, LoadingService>();
            builder.Services.AddSingleton<IToastService, ToastService>();

            builder.Services.AddHttpClient<GooglePlacesService>();
            builder.Services.AddHttpClient<OpenWeatherService>();
            builder.Services.AddHttpClient<TomorrowService>();
            builder.Services.AddHttpClient<WeatherApiService>();
            builder.Services.AddHttpClient<WeatherStackService>();
            builder.Services.AddHttpClient<ForecaService>();
            builder.Services.AddHttpClient<HereService>();
            builder.Services.AddHttpClient<OpenStreetMapService>();

            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<LocalViewModel>();
            builder.Services.AddSingleton<SettingViewModel>();
            builder.Services.AddSingleton<TourismViewModel>();
            builder.Services.AddSingleton<WeatherViewModel>();

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<LocalPage>();
            builder.Services.AddTransient<SettingPage>();
            builder.Services.AddTransient<TourismPage>();
            builder.Services.AddTransient<WeatherPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
