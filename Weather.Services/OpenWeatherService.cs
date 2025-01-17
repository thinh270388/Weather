using Newtonsoft.Json;
using Weather.Models.DTOs;
using Weather.Models.Helpers;
using Weather.Models.Responses;

namespace Weather.Services
{
    public class OpenWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://api.openweathermap.org/data/2.5/";
        public OpenWeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CurrentResponse> GetCurrentWeatherAsync(string location, string apiKey)
        {
            string url = $"{baseUrl}weather?q={location}&appid={apiKey}&units=metric";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result =  JsonConvert.DeserializeObject<CurrentOW>(json)!;
                    return new CurrentResponse()
                    {
                        City = result.Name!,
                        Nation = result.Sys!.Country!,
                        Location = $"{result.Name!}, {result.Sys!.Country!}",
                        Coordinates = $"(Vĩ độ: {result.Coord!.Lat}; Kinh độ: {result.Coord.Lon})",
                        Latitude = result.Coord!.Lat,
                        Longitude = result.Coord.Lon,
                        Description = ConvertHelper.TranslateOW(result.Weather!.FirstOrDefault()!.Id!),
                        Icon = $"Images/OpenWeather/img_{result.Weather!.FirstOrDefault()!.Icon!}.png",
                        Temperature = result.Main!.Temp,
                        Humidity = result.Main!.Humidity,
                        Pressure = result.Main!.Pressure,
                        WindSpeed = result.Wind!.Speed!,
                        UpdateAt = DateTime.Now,
                        UpdateBy = "OpenWeather"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                Console.Write(ex.StackTrace);
            }
            return null!;
        }
        public async Task<CurrentResponse> GetCurrentWeatherAsync(double? latitude, double? longitude, string? apiKey)
        {
            string url = $"{baseUrl}weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CurrentOW>(json)!;
                    return new CurrentResponse()
                    {
                        City = result.Name!,
                        Nation = result.Sys!.Country!,
                        Location = $"{result.Name!}, {result.Sys!.Country!}",
                        Coordinates = $"(Vĩ độ: {result.Coord!.Lat}; Kinh độ: {result.Coord.Lon})",
                        Latitude = result.Coord!.Lat,
                        Longitude = result.Coord.Lon,
                        Description = ConvertHelper.TranslateOW(result.Weather!.FirstOrDefault()!.Id!),
                        Icon = $"Images/OpenWeather/img_{result.Weather!.FirstOrDefault()!.Icon!}.png",
                        Temperature = result.Main!.Temp,
                        Humidity = result.Main!.Humidity,
                        Pressure = result.Main!.Pressure,
                        WindSpeed = result.Wind!.Speed!,
                        UpdateAt = DateTime.Now,
                        UpdateBy = "OpenWeather"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                Console.Write(ex.StackTrace);
            }
            return null!;
        }
        public async Task<List<ForecastResponse>> GetForecastWeatherAsync(string? location, int? days, string? apiKey)
        {
            string url = $"{baseUrl}forecast?q={location}&cnt={days}&appid={apiKey}&units=metric";
            try
            {
                HttpResponseMessage response = await _httpClient!.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<ForecastOW>(json)!;
                    List<ForecastResponse> list = new();
                    foreach (ForecastItem result in results.List!)
                    {
                        var dateTime = result.Dt_Txt!.Split(" ");
                        list.Add(new ForecastResponse()
                        {
                            Description = ConvertHelper.TranslateOW(result.Weather!.FirstOrDefault()!.Id!),
                            Icon = $"Images/OpenWeather/img_{result.Weather!.FirstOrDefault()!.Icon!}.png",
                            Dt_Txt = dateTime[0],
                            Time = dateTime[1],
                            Temp = result.Main!.Temp,
                            Temp_Min = result.Main!.Temp_Min,
                            Temp_Max = result.Main!.Temp_Max,
                            Pressure = result.Main!.Pressure,
                            Humidity = result.Main!.Humidity,
                            WindSpeed = result.Wind!.Speed!,
                        });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                Console.Write(ex.StackTrace);
            }
            return null!;
        }
        public async Task<AirPollutionResponse> GetAirPollutionAsync(double? lat, double? lon, string? apiKey)
        {
            string url = $"{baseUrl}air_pollution?lat={lat}&lon={lon}&appid={apiKey}";
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response != null)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<AirPollutionOW>(json)!;
                    return new AirPollutionResponse()
                    {
                        AirQuality = ConvertHelper.AirPollutionOW(result!.List![0].Main!.Aqi),
                        CO = result.List[0].Components!.Co,
                        NO2 = result.List[0].Components!.No2,
                        O3 = result.List[0].Components!.O3,
                        PM10 = result.List[0].Components!.Pm10,
                        PM25 = result.List[0].Components!.Pm25,
                        SO2 = result.List[0].Components!.So2
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
            return null!;
        }
        public async Task<List<LocationOW>> GetLocationsAsync(string? query, string? apiKey)
        {
            string url = $"https://api.openweathermap.org/geo/1.0/direct?q={query}&limit=5&appid={apiKey}";
            try
            {
                HttpResponseMessage response = await _httpClient!.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var locations = JsonConvert.DeserializeObject<List<LocationOW>>(jsonResponse);

                    return locations!;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                Console.Write(ex.StackTrace);
            }
            return null!;
        }
    }
}
