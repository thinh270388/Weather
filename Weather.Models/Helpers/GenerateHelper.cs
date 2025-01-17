using System.Collections.ObjectModel;

namespace Weather.Models.Helpers
{
    public class GenerateHelper
    {
        public static ObservableCollection<string> GetLocalLocations()
        {
            var locations = new ObservableCollection<string>();
            locations.Add("Phan Rang");
            locations.Add("Ninh Hải");
            locations.Add("Thuận Bắc");
            locations.Add("Ninh Phước");
            locations.Add("Thuận Nam");
            locations.Add("Ninh Sơn");
            locations.Add("Bác Ái");

            return locations;
        }
        public static ObservableCollection<string> GetSourceApis()
        {
            var sources = new ObservableCollection<string>();
            sources.Add("openweather.co.uk");
            sources.Add("tomorrow.io");
            sources.Add("weatherapi.com");
            sources.Add("weatherstack.com");

            return sources;
        }
    }
}
