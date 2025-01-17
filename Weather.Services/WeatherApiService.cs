using Newtonsoft.Json;
using Weather.Models;
using Weather.Models.Helpers;
using Weather.Models.Responses;

namespace Weather.Services
{
    public class WeatherApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://api.weatherapi.com/v1/";
        public WeatherApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CurrentResponse> GetCurrentWeatherAsync(string location, string apiKey)
        {
            string url = $"{baseUrl}current.json?key={apiKey}&q={location}";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CurrentWeatherApi>(json)!;
                    return new CurrentResponse()
                    {
                        City = result.Location!.Name!,
                        Nation = result.Location.Country!,
                        Location = $"{result.Location.Name!}, {result.Location!.Country!}",
                        Coordinates = $"(Vĩ độ: {result.Location!.Lat}; Kinh độ: {result.Location.Lon})",
                        Latitude = result.Location!.Lat,
                        Longitude = result.Location.Lon,
                        Description = ConvertHelper.ConvertWeatherApi(result.Current!.Condition!.Text!.Trim().ToLower()),
                        Icon = $"https:{result.Current!.Condition!.Icon}",
                        Temperature = result.Current!.Temp_C,
                        Humidity = result.Current!.Humidity,
                        Pressure = result.Current!.Pressure_Mb,
                        WindSpeed = (double?)Math.Round(Convert.ToDecimal(result.Current!.Wind_Kph! * 0.27778), 1, MidpointRounding.ToZero),
                        UpdateAt = DateTime.Now,
                        UpdateBy = "WeatherApi"
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
            var url = $"{baseUrl}forecast.json?key={apiKey}&q={location}&days={days}";
            List<ForecastResponse> list = new();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var results =  JsonConvert.DeserializeObject<ForecastWeatherApi>(json)!;

                    foreach (var day in results.Forecast!.Forecastday!)
                    {
                        foreach (var hour in day.Hour!)
                        {
                            var dateTime = hour.Time!.Split(" ");
                            list.Add(new ForecastResponse()
                            {
                                Description = ConvertHelper.ConvertWeatherApi(hour.Condition!.Text!.Trim().ToLower()),
                                Dt_Txt = dateTime[0],
                                Time = dateTime[1],
                                Icon = $"https:{hour.Condition!.Icon}",
                                Temp = hour.Temp_C,
                                Pressure = hour.Pressure_Mb,
                                Humidity = hour.Humidity,
                                WindSpeed = (double?)Math.Round(Convert.ToDecimal(hour.Wind_Kph! * 0.27778), 1, MidpointRounding.ToZero),
                            });
                        }                        
                    }                    
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
