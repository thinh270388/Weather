namespace Weather.Models.DTOs
{
    public class WeatherStack
    {
        public class WeatherRequest
        {
            public string? Type { get; set; }
            public string? Query { get; set; }
            public string? Language { get; set; }
            public string? Unit { get; set; }
        }

        public class LocationWS
        {
            public string? Name { get; set; }
            public string? Country { get; set; }
            public string? Region { get; set; }
            public double? Lat { get; set; }
            public double? Lon { get; set; }
            public string? Timezone_Id { get; set; }
            public string? Localtime { get; set; }
            public long? Localtime_Epoch { get; set; }
            public string? Utc_Offset { get; set; }
        }

        public class CurrentWeather
        {
            public string? Observation_Time { get; set; }
            public int? Temperature { get; set; }
            public int? Weather_Code { get; set; }
            public List<string>? Weather_Icons { get; set; }
            public List<string>? Weather_Descriptions { get; set; }
            public int? Wind_Speed { get; set; }
            public int? Wind_Degree { get; set; }
            public string? Wind_Dir { get; set; }
            public int? Pressure { get; set; }
            public double? Precip { get; set; }
            public int? Humidity { get; set; }
            public int? Cloudcover { get; set; }
            public int? Feelslike { get; set; }
            public int? Uv_Index { get; set; }
            public int? Visibility { get; set; }
            public string? Is_Day { get; set; }
        }

        public class CurrentWeatherStack
        {
            public WeatherRequest? Request { get; set; }
            public LocationWS? Location { get; set; }
            public CurrentWeather? Current { get; set; }
        }

    }
}
