using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Weather.Mobile.Helpers;
using Weather.Mobile.Services.Constracts;
using Weather.Models.Helpers;
using Weather.Services;

namespace Weather.Mobile.ViewModels
{
    public partial class SettingViewModel : BaseViewModel
    {
        private readonly IToastService _toastService;
        private readonly GoogleSheetsService _googleSheetsService;

        [ObservableProperty]
        private ObservableCollection<string> sourceApis = [];
        [ObservableProperty]
        private ObservableCollection<string> sourceSheets = [];
        [ObservableProperty]
        private ObservableCollection<string> locations = [];
        [ObservableProperty]
        private string selectedSourceApi = string.Empty; 
        [ObservableProperty]
        private string selectedSourceSheet = string.Empty;
        [ObservableProperty]
        private string locationApi = string.Empty;
        [ObservableProperty]
        private string locationLocal = string.Empty;
        [ObservableProperty]
        private string locationTourism = string.Empty;
        [ObservableProperty]
        private bool isAutoUpdateEnabled = false;
        [ObservableProperty]
        private bool isClayLocal = false;
        [ObservableProperty]
        private int heightWebView = 1500;

        public SettingViewModel(IToastService toastService, GoogleSheetsService googleSheetsService)
        {
            _toastService = toastService;
            _googleSheetsService = googleSheetsService;

            Task.Run(async () => await LoadSettings());
        }
        public async Task LoadSettings()
        {
            try
            {                
                Locations = GenerateHelper.GetLocalLocations();
                LocationLocal = Preferences.Get(SettingKeys.LastLocationLocal, Locations.FirstOrDefault()!);
                LocationTourism = Preferences.Get(SettingKeys.LastLocationTourism, Locations.FirstOrDefault()!);

                SourceApis = GenerateHelper.GetSourceApis();
                SelectedSourceApi = Preferences.Get(SettingKeys.LastSourceApi, SourceApis.FirstOrDefault()!);

                LocationApi = Preferences.Get(SettingKeys.LastLocationApi, "Đà Lạt");
                IsAutoUpdateEnabled = Preferences.Get(SettingKeys.IsAutoUpdateEnabled, true);

                IsClayLocal = Preferences.Get(SettingKeys.IsClayLocal, false);
                HeightWebView = Preferences.Get(SettingKeys.HeightWebView, 1500);

                var result = await _googleSheetsService.GetSheetNamesAsync(ConstantHelper.GoogleSpreadsheetId);
                SourceSheets = new(result.Where(x => !x.Contains("Du lịch") && !x.Contains("Thời tiết")));
                if (SourceSheets.Count > 0)
                {
                    SelectedSourceSheet = Preferences.Get(SettingKeys.LastSourceSheet, SourceSheets.FirstOrDefault()!);
                }
            }
            catch (Exception ex)
            {
                await _toastService.ShowAlert("Thông báo", $"Có lỗi xảy ra khi nạp cài đặt: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private async Task Save()
        {
            try
            {
                Preferences.Set(SettingKeys.LastSourceSheet, SelectedSourceSheet);
                Preferences.Set(SettingKeys.LastSourceApi, SelectedSourceApi);

                Preferences.Set(SettingKeys.LastLocationApi, LocationApi);
                Preferences.Set(SettingKeys.LastLocationLocal, LocationLocal);
                Preferences.Set(SettingKeys.LastLocationTourism, LocationTourism);

                Preferences.Set(SettingKeys.IsAutoUpdateEnabled, IsAutoUpdateEnabled);
                Preferences.Set(SettingKeys.IsClayLocal, IsClayLocal);
                Preferences.Set(SettingKeys.HeightWebView, HeightWebView);

                await _toastService.ShowAlert("Thông báo", "Lưu cài đặt thành công", "OK");
            }
            catch (Exception ex)
            {
                await _toastService.ShowAlert("Thông báo", $"Có lỗi xảy ra khi lưu cài đặt: {ex.Message}", "OK");
            }
        }
    }
}
