using Newtonsoft.Json;
using Weather.Models.Helpers;
using Weather.Models.Responses;
using static Weather.Models.DTOs.WeatherStack;

namespace Weather.Services
{
    public class WeatherStackService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://api.weatherstack.com/";
        public WeatherStackService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CurrentResponse> GetCurrentWeatherAsync(string location, string apiKey)
        {
            string url = $"{baseUrl}current?access_key={apiKey}&query={location}";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CurrentWeatherStack>(json)!;
                    return new CurrentResponse()
                    {
                        City = result.Location!.Name!,
                        Nation = result.Location.Country!,
                        Location = $"{result.Location.Name!}, {result.Location!.Country!}",
                        Coordinates = $"(Vĩ độ: {result.Location!.Lat}; Kinh độ: {result.Location.Lon})",
                        Latitude = result.Location!.Lat,
                        Longitude = result.Location.Lon,
                        Description = ConvertHelper.ConvertWeatherApi(result.Current!.Weather_Descriptions![0].Trim().ToLower()),
                        Icon = result.Current!.Weather_Icons![0],
                        Temperature = result.Current!.Temperature,
                        Humidity = result.Current!.Humidity,
                        Pressure = result.Current!.Pressure,
                        WindSpeed = (double?)Math.Round(Convert.ToDecimal(result.Current!.Wind_Speed! * 0.27778), 1, MidpointRounding.ToZero),
                        UpdateAt = DateTime.Now,
                        UpdateBy = "WeatherStack"
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

        public async Task<List<ForecastResponse>> GetForecastWeatherAsync(string location, int days, string apiKey)
        {
            string url = $"{baseUrl}forecast?access_key={apiKey}&query={location}&forecast_days={days}&hourly=1";
            List<ForecastResponse> list = new();
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    // var result = JsonConvert.DeserializeObject<CurrentWeatherStack>(json)!;

                    // Nâng cấp tài khoản mới sử dụng được
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                Console.Write(ex.StackTrace);
            }
            return list;
        }
    }
}
