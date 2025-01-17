using Newtonsoft.Json.Linq;

namespace Weather.Services
{
    public class OpenStreetMapService
    {
        HttpClient _httpClient;
        public OpenStreetMapService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetLocationAsync(double lat, double lon)
        {
            try
            {
                string url = $"https://nominatim.openstreetmap.org/reverse?lat={lat.ToString().Replace(",", ".")}&lon={lon.ToString().Replace(",", ".")}&format=json";
                var response = await _httpClient.GetStringAsync(url);

                // Phân tích dữ liệu JSON
                var locationData = JObject.Parse(response);
                return locationData.Count > 0 ? locationData["display_name"]!.Value<string>()! : null!; // Trả về display_name
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null!;
            }
        }
    }
}
