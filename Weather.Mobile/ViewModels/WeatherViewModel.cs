using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Weather.Mobile.Helpers;
using Weather.Mobile.Services.Constracts;
using Weather.Models.Helpers;
using Weather.Models.Responses;
using Weather.Services;

namespace Weather.Mobile.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        private readonly ILoadingService _loadingService;
        private readonly IToastService _toastService;

        private readonly OpenWeatherService _openWeatherService;
        private readonly TomorrowService _tomorrowService;
        private readonly WeatherApiService _weatherApiService;
        private readonly WeatherStackService _weatherStackService;

        public ICommand RefreshCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand SpeakCommand { get; private set; }
        public ICommand VisibleAlertCommand { get; private set; }
        public ICommand VisibleForecastCommand { get; private set; }

        private string _location = string.Empty;
        private string _selectedSourceApi = string.Empty;
        private ObservableCollection<string> _sourcesApis = new();
        private CurrentResponse _current = new();
        private AirPollutionResponse _airPollution = new();
        private ObservableCollection<ForecastResponse> _forecasts = new();
        private string _alert = "Thông báo tự động";

        private bool isShowAlert = true;
        private bool isShowForecast = true;
        private bool isOnline = false;

        public WeatherViewModel(ILoadingService loadingService, IToastService toastService, OpenWeatherService openWeatherService, TomorrowService tomorrowService, WeatherApiService weatherApiService, WeatherStackService weatherStackService)
        {
            _loadingService = loadingService;
            _toastService = toastService;

            _openWeatherService = openWeatherService;
            _tomorrowService = tomorrowService;
            _weatherApiService = weatherApiService;
            _weatherStackService = weatherStackService;

            SearchCommand = new AsyncRelayCommand(Search);
            SpeakCommand = new AsyncRelayCommand(Speak);
            VisibleAlertCommand = new AsyncRelayCommand(VisibleAlert);
            VisibleForecastCommand = new AsyncRelayCommand(VisibleForecast);
            RefreshCommand = new AsyncRelayCommand(Search);

            LoadSettings();
        }
        private async Task VisibleAlert()
        {
            await _loadingService.ShowLoadingAsync("Tải dữ liệu...");
            IsShowAlert = !IsShowAlert;
            await _loadingService.HideLoadingAsync();
        }
        private async Task VisibleForecast()
        {
            await _loadingService.ShowLoadingAsync("Tải dữ liệu...");
            IsShowForecast = !IsShowForecast;
            await _loadingService.HideLoadingAsync();
        }
        public void LoadSettings()
        {
            Location = Preferences.Get(SettingKeys.LastLocationApi, "HaNoi");
            SourceApis = GenerateHelper.GetSourceApis();
            SelectedSourceApi = Preferences.Get(SettingKeys.LastSourceApi, SourceApis.FirstOrDefault()!);
        }
        private async Task Speak()
        {
            try
            {
                if (!string.IsNullOrEmpty(Alert))
                    await TextToSpeech.SpeakAsync(Alert);
            }
            catch (Exception ex)
            {
                await _toastService.ShowAlert("Thông báo", $"Không thể đọc thông báo vì lỗi: {ex.Message}", "OK");
            }
        }
        private async Task Search()
        {
            try
            {
                await _loadingService.ShowLoadingAsync("Tải dữ liệu ...");
                await GetData(Location, SelectedSourceApi);
            }
            finally
            {
                await _loadingService.HideLoadingAsync();
            }
        }
        private async Task GetData(string location, string selectedSource)
        {
            if (!NetworkHelper.IsNetworkAvailable())
            {
                IsOnline = false;
                await _toastService.ShowAlert("Thông báo", "Không có kết nối mạng! Vui lòng kiểm tra lại kết nối", "OK");
                return;
            }
            else
            {
                IsOnline = true;
            }    

            Current = new();
            AirPollution = new();
            Forecasts = new();
            Alert = string.Empty;            
            Preferences.Set(SettingKeys.LastLocationApi, location);
            Preferences.Set(SettingKeys.LastSourceApi, selectedSource);

            try
            {
                if (selectedSource.Equals("openweather.co.uk"))
                {
                    Current = await _openWeatherService.GetCurrentWeatherAsync(location, ConstantHelper.OpenWeatherApiKey);
                    if (Current == null)
                    {
                        await _toastService.ShowAlert("Thông báo", $"({location}) chưa có dữ liệu", "OK");
                        return;
                    }

                    AirPollution = await _openWeatherService.GetAirPollutionAsync(Current.Latitude, Current.Longitude, ConstantHelper.OpenWeatherApiKey);

                    var foreCasts = await _openWeatherService.GetForecastWeatherAsync(location, 24, ConstantHelper.OpenWeatherApiKey);
                    Forecasts = new(foreCasts);
                }
                else if (selectedSource.Equals("tomorrow.io"))
                {
                    Current = await _tomorrowService.GetCurrentWeatherAsync(location, ConstantHelper.TomorrowApiKey);
                    if (Current == null)
                    {
                        await _toastService.ShowAlert("Thông báo", $"({location}) chưa có dữ liệu", "OK");
                        return;
                    }
                    var foreCasts = await _tomorrowService.GetForecastWeatherAsync(location, ConstantHelper.TomorrowApiKey);
                    Forecasts = new(foreCasts);
                }
                else if (selectedSource.Equals("weatherapi.com"))
                {
                    Current = await _weatherApiService.GetCurrentWeatherAsync(location, ConstantHelper.WeatherApiKey);
                    if (Current == null)
                    {
                        await _toastService.ShowAlert("Thông báo", $"({location}) chưa có dữ liệu", "OK");
                        return;
                    }
                    var foreCasts = await _weatherApiService.GetForecastWeatherAsync(location, 3, ConstantHelper.WeatherApiKey);
                    Forecasts = new(foreCasts);
                }
                else if (selectedSource.Equals("weatherstack.com"))
                {
                    Current = await _weatherStackService.GetCurrentWeatherAsync(location, ConstantHelper.WeatherStackApiKey);
                    if (Current == null)
                    {
                        await _toastService.ShowAlert("Thông báo", $"({location}) chưa có dữ liệu", "OK");
                        return;
                    }
                    var foreCasts = await _weatherStackService.GetForecastWeatherAsync(location, 3, ConstantHelper.WeatherStackApiKey);
                    Forecasts = new(foreCasts);
                }

                string warning = string.Empty;
                warning += ConvertHelper.TemperatureWarning(Current.Temperature);
                warning += $"\n{ConvertHelper.WindWarning(Current.WindSpeed)}";

                Alert = warning;
            }
            catch (Exception ex)
            {
                await _toastService.ShowAlert("Thông báo", $"Xảy ra lỗi khi truy cập API thời tiết: {ex.Message}", "OK");
            }
        }

        public string Location { get => _location; set => SetProperty(ref _location, value); }
        public string SelectedSourceApi
        {
            get => _selectedSourceApi;
            set
            {
                SetProperty(ref _selectedSourceApi, value);
                if (value != null)
                {
                    Task.Run(async () => await Search());
                }
            }
        }
        public ObservableCollection<string> SourceApis { get => _sourcesApis; set => SetProperty(ref _sourcesApis, value); }
        public CurrentResponse Current { get => _current; set => SetProperty(ref _current, value); }
        public AirPollutionResponse AirPollution { get => _airPollution; set => SetProperty(ref _airPollution, value); }
        public string Alert { get => _alert; set => SetProperty(ref _alert, value); }
        public ObservableCollection<ForecastResponse> Forecasts { get => _forecasts; set => SetProperty(ref _forecasts, value); }
        public bool IsShowAlert { get => isShowAlert; set => SetProperty(ref isShowAlert, value); }
        public bool IsShowForecast { get => isShowForecast; set => SetProperty(ref isShowForecast, value); }
        public bool IsOnline { get => isOnline; set => SetProperty(ref isOnline, value); }
    }
}
