using Newtonsoft.Json;
using Weather.Models.DTOs;

namespace Weather.Services
{
    public class ForecaService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://pfa.foreca.com/api/v1/";
        public ForecaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetCurrentWeatherAsync(string location, string apiKey)
        {
            string loca = "100658225";
            string url = $"{baseUrl}current/{loca}?token={apiKey}";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CurrentOW>(json)!;
                    return null!;
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
