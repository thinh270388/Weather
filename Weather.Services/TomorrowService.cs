using Newtonsoft.Json;
using Weather.Models;
using Weather.Models.Responses;

namespace Weather.Services
{
    public class TomorrowService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://api.tomorrow.io/v4/weather/";
        public TomorrowService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CurrentResponse> GetCurrentWeatherAsync(string location, string apiKey)
        {
            string url = $"{baseUrl}realtime?location={location}&apikey={apiKey}";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CurrentTomorrow>(json)!;
                    return new CurrentResponse()
                    {
                        City = result.Location!.Name!,
                        Nation = result.Location!.Name!,
                        Location = result.Location!.Name!,
                        Coordinates = $"(Vĩ độ: {result.Location!.Lat}; Kinh độ: {result.Location.Lon})",
                        Latitude = result.Location!.Lat,
                        Longitude = result.Location.Lon,
                        Description = result.Data!.Values!.WeatherCode.ToString()!,
                        Icon = result.Data!.Values!.WeatherCode.ToString()!,
                        Temperature = result.Data!.Values!.Temperature!,
                        Humidity = result.Data.Values!.Humidity,
                        Pressure = result.Data.Values!.PressureSurfaceLevel,
                        WindSpeed = result.Data.Values!.WindSpeed,
                        UpdateAt = DateTime.Now,
                        UpdateBy = "Tomorrow",
                        PrecipitationProbability = result.Data.Values.PrecipitationProbability,
                        RainIntensity = result.Data.Values!.RainIntensity
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
        public async Task<List<ForecastResponse>> GetForecastWeatherAsync(string location, string apiKey)
        {
            string url = $"{baseUrl}forecast?location={location}&apikey={apiKey}";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<ForecastTomorrow>(json)!;

                    List<ForecastResponse> list = new();
                    foreach (HourlyData result in results.Timelines!.Hourly!)
                    {
                        var dateTime = result.Time!.ToString()!.Split(" ");
                        list.Add(new ForecastResponse()
                        {
                            Description = result.Values!.WeatherCode.ToString(),
                            Icon = result.Values!.WeatherCode.ToString(),
                            Dt_Txt = dateTime[0],
                            Time = dateTime[1],
                            Temp = result.Values!.Temperature,
                            Pressure = result.Values!.PressureSurfaceLevel,
                            Humidity = result.Values!.Humidity,
                            WindSpeed = result.Values!.WindSpeed!,
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
    }
}
