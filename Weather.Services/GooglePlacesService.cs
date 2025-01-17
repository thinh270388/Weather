using Newtonsoft.Json.Linq;
using System.Net.Http;
using Weather.Models.Helpers;

namespace Weather.Services
{
    public class GooglePlacesService
    {
        private readonly HttpClient _httpClient;
        //private readonly string baseUrl = "https://maps.googleapis.com/maps/api/place/";

        public GooglePlacesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetPlacesAsync(string location, string type)
        {
            try
            {
                var url = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={location}&type={type}&key={ConstantHelper.GooglePlacesApiKey}";

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
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
