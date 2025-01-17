using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Weather.Mobile.Helpers;
using Weather.Mobile.Services.Constracts;
using Weather.Models;
using Weather.Models.DTOs;
using Weather.Models.Helpers;
using Weather.Services;

namespace Weather.Mobile.ViewModels
{
    public partial class TourismViewModel : BaseViewModel
    {
        private readonly ILoadingService _loadingService;
        private readonly IToastService _toastService;
        private readonly GoogleSheetsService _googleSheetsService;
        private readonly IConnectivity _connectivity;
        private readonly IMap _map;
        private readonly IGeolocation _geolocation;
        private readonly HereService _hereService;
        private readonly OpenStreetMapService _openStreetMapService;

        [ObservableProperty]
        private ObservableCollection<string> locations = new();
        private string selectedLocation = string.Empty;
        [ObservableProperty]
        private ObservableCollection<LocalTourism> localTourismFulls = new();
        [ObservableProperty]
        private ObservableCollection<LocalTourism> localTourisms = new();
        [ObservableProperty]
        private LocalTourism selectedLocalTourism = new();
        [ObservableProperty]
        private ObservableCollection<CurrentLocal> currentLocals = new();
        private CurrentLocal selectedCurrentLocal = new();
        [ObservableProperty]
        private bool isShowPlaceDetail = true;
        [ObservableProperty]
        private bool isShowTimeTourist = true;
        [ObservableProperty]
        private string locationName = string.Empty;
        [ObservableProperty]
        private bool isOnline = false;

        public TourismViewModel(ILoadingService loadingService, 
            IToastService toastService, 
            GoogleSheetsService googleSheetsService, 
            IConnectivity connectivity, 
            IMap map, 
            IGeolocation geolocation, 
            HereService hereService,
            OpenStreetMapService openStreetMapService)
        {
            _loadingService = loadingService;
            _toastService = toastService;
            _googleSheetsService = googleSheetsService;
            _connectivity = connectivity;
            _map = map;
            _geolocation = geolocation;
            _hereService = hereService;
            _openStreetMapService = openStreetMapService;

            Locations = GenerateHelper.GetLocalLocations();
            SelectedLocation = Preferences.Get(SettingKeys.LastLocationTourism, Locations.FirstOrDefault()!);
            Task.Run(async () => await Refresh());
        }

        [RelayCommand]
        private void VisiblePlaceDetail()
        {
            IsShowPlaceDetail = !IsShowPlaceDetail;
        }
        [RelayCommand]
        private void VisibleTimeTourist()
        {
            IsShowTimeTourist = !IsShowTimeTourist;
        }
        private async Task LoadData()
        {
            try
            {
                if (_connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    IsOnline = false;
                    await Shell.Current.DisplayAlert("Không có kết nối mạng!",
                        $"Vui lòng kiểm tra internet và thử lại.", "OK");
                    return;
                }
                else
                {
                    IsOnline = true;
                }    

                // LẤY DỮ LIỆU DU LỊCH
                await _loadingService.ShowLoadingAsync("Tải dữ liệu ...");

                var result = await _googleSheetsService.ReadEntireSheetAsync(ConstantHelper.GoogleSpreadsheetId, "Du lịch");
                LocalTourismFulls = new();

                // Get cached location, else get real location.
                var location = await _geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Best,
                    Timeout = TimeSpan.FromSeconds(30)
                });

                if (location != null)
                {
                    LocationName = await _openStreetMapService.GetLocationAsync(location.Latitude, location.Longitude);
                }

                foreach (var item in result)
                {
                    if (item[0].ToString()!.Equals("STT")) continue;
                    LocalTourism x = new()
                    {
                        PlaceLocal = item[1].ToString(),
                        Name = item[2].ToString(),
                        Address = item[3].ToString(),
                        Infomation = item[5].ToString(),
                        Time = item[6].ToString(),
                        PhoneNumber = item[7].ToString(),
                        Website = item[8].ToString(),
                        Utility = item[9].ToString(),
                        Price = item[10].ToString(),
                        Point = string.IsNullOrEmpty(item[11].ToString()) ? null : Convert.ToDecimal(item[11].ToString()!),
                        Coordinates = item[13].ToString()
                    };

                    var imageList = item[4].ToString()!.Split("|");
                    if (imageList.Length > 0)
                    {
                        List<string> list = new();
                        foreach (string s in imageList)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                list.Add($"\"{s}\"");
                            }
                            else
                            {
                                list.Add("Chưa có hình ảnh");
                            }
                        }
                        x.Images = list;
                    }

                    var commentList = item[12].ToString()!.Split("|");
                    if (commentList.Length > 0)
                    {
                        List<string> list = new();
                        foreach (string s in commentList)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                list.Add(s);
                            }
                            else
                            {
                                list.Add("Chưa có đánh giá");
                            }
                        }
                        x.Comments = list;
                    }

                    if (location != null && !string.IsNullOrEmpty(item[13].ToString()))
                    {
                        // 11.593357/109.030461
                        var coordinates = item[13].ToString()!.Split(",");
                        var endLat = Convert.ToDouble(coordinates[0].Replace(".", ","));
                        var endLon = Convert.ToDouble(coordinates[1].Replace(".", ","));
                        x.Distance = CalculateDistance(location.Latitude, location.Longitude, endLat, endLon);
                        var data = await _hereService.GetDrivingDistance(location.Latitude, location.Longitude, endLat, endLon);
                        x.DistanceDriving = (double?)Math.Round(Convert.ToDecimal(data.DistanceDriving), 2);
                        x.TimeDriving = data.TimeDriving;
                    }

                    LocalTourismFulls.Add(x);
                }
                LocalTourisms = new(LocalTourismFulls.Where(x => x.PlaceLocal!.Equals(SelectedLocation)));
                if (LocalTourisms != null)
                {
                    SelectedLocalTourism = LocalTourisms!.FirstOrDefault()!;
                }

                // LẤY DỮ LIỆU THỜI TIẾT
                ObservableCollection<LocalWeather> LocalWeathers = new();
                var sheets = await _googleSheetsService.GetSheetNamesAsync(ConstantHelper.GoogleSpreadsheetId);
                var sheetDate = Convert.ToDateTime(sheets.FirstOrDefault(x => !x.Contains("Du lịch") && !x.Contains("Thời tiết")));
                foreach (var item in sheets)
                {
                    if (!item.Contains("Du lịch") && !item.Contains("Thời tiết"))
                    {
                        var date = Convert.ToDateTime(item.ToString());
                        if (date > sheetDate)
                        {
                            sheetDate = date;
                        }
                    }
                }
                if (Preferences.Get(SettingKeys.IsAutoUpdateEnabled, true))
                    Preferences.Set(SettingKeys.LastSourceSheet, sheetDate.ToString("dd/MM/yyyy"));
                string sheetName = Preferences.Get(SettingKeys.LastSourceSheet, sheetDate.ToString("dd/MM/yyyy"));
                var datas = await _googleSheetsService.ReadEntireSheetAsync(ConstantHelper.GoogleSpreadsheetId, sheetName);

                for (int row = 2; row < datas.Count; row++)
                {
                    var diaDiemDuBao = datas[row][0].ToString();
                    var localWeather = new LocalWeather
                    {
                        DiaDiemDuBao = diaDiemDuBao,
                        Currents = new()
                    };

                    CurrentLocal current = null!;

                    for (int col = 1; col < datas[row].Count; col++)
                    {
                        var dateCell = datas[0][col].ToString();
                        var headerCell = datas[1][col].ToString();
                        var cellValue = datas[row][col].ToString();

                        if (!string.IsNullOrEmpty(dateCell))
                        {
                            current = new CurrentLocal { ThoiGian = dateCell };
                            localWeather.Currents.Add(current);
                        }

                        if (current == null) continue;

                        switch (headerCell)
                        {
                            case "Tm": current.Tm = int.TryParse(cellValue, out int tm) ? tm : (int?)null; break;
                            case "Tx": current.Tx = int.TryParse(cellValue, out int tx) ? tx : (int?)null; break;
                            case "R": current.R = int.TryParse(cellValue, out int r) ? r : (int?)null; break;
                            case "Xác suất mưa": current.XacSuatMua = int.TryParse(cellValue, out int xsm) ? xsm : (int?)null; break;
                            case "H. gió": current.HuongGio = cellValue; break;
                            case "Tốc độ gió": current.TocDoGio = int.TryParse(cellValue, out int tdg) ? tdg : (int?)null; break;
                            case "Đ.ẩm": current.DoAm = int.TryParse(cellValue, out int dam) ? dam : (int?)null; break;
                            case "T.tiết": current.ThoiTiet = int.TryParse(cellValue, out int tt) ? tt : (int?)null; break;
                            default: break;
                        }
                    }
                    LocalWeathers.Add(localWeather);
                }

                // LỌC CÁC NGÀY >= NGÀY HIỆN TẠI
                if (!string.IsNullOrEmpty(SelectedLocation))
                {
                    CurrentLocals.Clear();
                    foreach (var item in LocalWeathers)
                    {
                        if (item.DiaDiemDuBao!.Equals(SelectedLocation))
                        {
                            foreach (var item1 in item.Currents!)
                            {
                                if (Convert.ToDateTime(item1.ThoiGian) >= Convert.ToDateTime(DateTime.Today))
                                {
                                    CurrentLocals.Add(item1);
                                }
                            }
                        }
                    }
                    if (CurrentLocals.Count == 0)
                    {
                        CurrentLocals.Add(new CurrentLocal() { });
                    }
                }
            }
            catch (Exception ex)
            {
                await _toastService.ShowAlert("Thông báo", $"Có lỗi xảy ra khi tải dữ liệu: {ex.Message}", "OK");
            }
            finally
            {
                await _loadingService.HideLoadingAsync();
            }
        }
        private async Task Speak(string message)
        {
            try
            {
                await TextToSpeech.SpeakAsync(message);
            }
            catch (Exception ex)
            {
                await _toastService.ShowAlert("Thông báo", $"Không thể đọc thông báo vì lỗi: {ex.Message}", "OK");
            }
        }
        [RelayCommand]
        private async Task Refresh()
        {
            try
            {
                await LoadData();
            }
            catch (Exception ex)
            {
                await _toastService.ShowAlert("Thông báo", $"Có lỗi xảy ra khi làm mới dữ liệu: {ex.Message}", "OK");
            }
        }
        [RelayCommand]
        private async Task OpenMap()
        {
            try
            {
                var coordinates = SelectedLocalTourism.Coordinates!.Split(",");
                var destinationPosition = new Location(Convert.ToDouble(coordinates[0].Replace(".", ",")), Convert.ToDouble(coordinates[1].Replace(".", ",")));

                // Mở bản đồ với vị trí bắt đầu và kết thúc
                var options = new MapLaunchOptions
                {
                    Name = SelectedLocalTourism.Name,
                    NavigationMode = NavigationMode.None
                };

                await _map.OpenAsync(destinationPosition, options);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Lỗi", ex.Message, "OK");
            }
        }
        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // công thức Haversine
            const double R = 6371; // Bán kính Trái Đất (km)
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return Math.Round(R * c, 2); // Khoảng cách (km)
        }
        private static double ToRadians(double angle)
        {
            return angle * Math.PI / 180.0;
        }

        public string SelectedLocation
        {
            get => selectedLocation;
            set
            {
                SetProperty(ref selectedLocation, value);
                if (!string.IsNullOrEmpty(value))
                {
                    Preferences.Set(SettingKeys.LastLocationTourism, value);
                }
            }
        }
        public CurrentLocal SelectedCurrentLocal
        {
            get => selectedCurrentLocal;
            set
            {
                SetProperty(ref selectedCurrentLocal, value);
                if (value != null)
                {
                    string message = $"Thời tiết {value.ThoiGian}: {ConvertHelper.ConvertLocalWeather((int)value.ThoiTiet!)}.\n" +
                        $"{ConvertHelper.ConvertLocalTourism((int)value.ThoiTiet!)}";
                    if (!string.IsNullOrEmpty(message))
                    {
                        Task.Run(async () => await Speak(message));
                    }
                }
            }
        }
    }
}
