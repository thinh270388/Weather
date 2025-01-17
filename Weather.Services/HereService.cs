using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Weather.Models;
using Weather.Models.DTOs;
using Weather.Models.Helpers;

namespace Weather.Services
{
    public class HereService
    {
        HttpClient _httpClient;
        public HereService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HereAPI> GetDrivingDistance(double startLat, double startLon, double endLat, double endLon)
        {
            var url = $"https://router.hereapi.com/v8/routes?transportMode=car&origin={startLat.ToString().Replace(",", ".")},{startLon.ToString().Replace(",", ".")}&destination={endLat.ToString().Replace(",", ".")},{endLon.ToString().Replace(",", ".")}&return=summary&apikey={ConstantHelper.OpenRoutApiKey}";

            var response = await _httpClient.GetStringAsync(url);
            var jsonResponse = JObject.Parse(response);

            // Kiểm tra trạng thái phản hồi
            var routes = jsonResponse["routes"];
            if (routes!.HasValues)
            {
                var summary = routes[0]!["sections"]![0]!["summary"];
                double length = summary!["length"]!.Value<double>(); // Độ dài tính bằng mét
                double travelTime = summary!["duration"]!.Value<double>(); // Thời gian di chuyển tính bằng giây
                return new HereAPI()
                {
                    DistanceDriving = length / 1000, // Chuyển đổi sang km
                    TimeDriving = $"{(int)(travelTime / 3600)} giờ {(int)((travelTime % 3600) / 60)} phút"
                };
            }
            else
            {
                throw new Exception("Không tìm thấy lộ trình.");
            }
        }
    }
}
