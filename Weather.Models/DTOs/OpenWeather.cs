namespace Weather.Models.DTOs
{
    public class ForecastOW
    {
        public List<ForecastItem>? List { get; set; }
    }
    public class ForecastItem
    {
        public int Dt { get; set; }
        public Main? Main { get; set; }
        public List<Weather>? Weather { get; set; }
        public Clouds? Clouds { get; set; }
        public Wind? Wind { get; set; }
        public int Visibility { get; set; }
        public double Pop { get; set; }
        public Rain? Rain { get; set; }
        public Sys? Sys { get; set; }
        public string? Dt_Txt { get; set; }
    }
    public class CurrentOW
    {
        public Coord? Coord { get; set; }
        public List<Weather>? Weather { get; set; }
        public Main? Main { get; set; }
        public Wind? Wind { get; set; }
        public Sys? Sys { get; set; }
        public string? Name { get; set; }
    }
    public class Clouds
    {
        public int All { get; set; }
    }
    public class Rain
    {
        public double? ThreeHourVolume { get; set; }
    }

    public class Sys
    {
        public string? Country { get; set; }
    }
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
    public class Weather
    {
        public int Id { get; set; }
        public string? Main { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }
    public class Main
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double Temp_Min { get; set; }
        public double Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }
    public class LocationOW
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
    public class AirPollutionOW
    {
        public Coord? Coord { get; set; }
        public List<AirQualityInfo>? List { get; set; }
    }
    public class MainInfo
    {
        public int Aqi { get; set; } // Air Quality Index
    }
    public class AirQualityInfo
    {
        public long Dt { get; set; }
        public MainInfo? Main { get; set; }
        public Components? Components { get; set; }
    }
    public class Components
    {
        public double Co { get; set; }
        public double No { get; set; }
        public double No2 { get; set; }
        public double O3 { get; set; }
        public double So2 { get; set; }
        public double Pm25 { get; set; }
        public double Pm10 { get; set; }
        public double Nh3 { get; set; }
    }
}
