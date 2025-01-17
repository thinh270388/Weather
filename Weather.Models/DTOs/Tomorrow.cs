namespace Weather.Models
{
    public class CurrentTomorrow
    {
        public Data? Data { get; set; }
        public LocationTomorrow? Location { get; set; }
    }
    public class Data
    {
        public DateTime? Time { get; set; }
        public Current? Values { get; set; }
    }

    public class Current
    {
        public double? CloudBase { get; set; }
        public double? CloudCeiling { get; set; }
        public int? CloudCover { get; set; }
        public double? DewPoint { get; set; }
        public double? FreezingRainIntensity { get; set; }
        public int? Humidity { get; set; }
        public int? PrecipitationProbability { get; set; }
        public double? PressureSurfaceLevel { get; set; }
        public double? RainIntensity { get; set; }
        public double? SleetIntensity { get; set; }
        public double? SnowIntensity { get; set; }
        public double? Temperature { get; set; }
        public double? TemperatureApparent { get; set; }
        public int? UvHealthConcern { get; set; }
        public int? UvIndex { get; set; }
        public double? Visibility { get; set; }
        public int? WeatherCode { get; set; }
        public double? WindDirection { get; set; }
        public double? WindGust { get; set; }
        public double? WindSpeed { get; set; }
    }

    public class LocationTomorrow
    {
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Type { get; set; } = string.Empty;
    }

    public class ForecastTomorrow
    {
        public TimelineData? Timelines { get; set; }
        public LocationTomorrow? Location { get; set; }
    }

    public class TimelineData
    {
        public List<MinutelyData>? Minutely { get; set; }
        public List<HourlyData>? Hourly { get; set; }
        public List<DailyData>? Daily { get; set; }
    }

    public class MinutelyData
    {
        public DateTime? Time { get; set; }
        public MinutelyValues? Values { get; set; }
    }

    public class MinutelyValues
    {
        public double? CloudBase { get; set; }
        public double? CloudCeiling { get; set; }
        public double? CloudCover { get; set; }
        public double? DewPoint { get; set; }
        public double? FreezeRainIntensity { get; set; }
        public double? Humidity { get; set; }
        public double? PrecipitationProbability { get; set; }
        public double? PressureSurfaceLevel { get; set; }
        public double? RainIntensity { get; set; }
        public double? SleetIntensity { get; set; }
        public double? SnowIntensity { get; set; }
        public double? Temperature { get; set; }
        public double? TemperatureApparent { get; set; }
        public double? UvHealthConcern { get; set; }
        public double? UvIndex { get; set; }
        public double? Visibility { get; set; }
        public int? WeatherCode { get; set; }
        public double? WindDirection { get; set; }
        public double? WindGust { get; set; }
        public double? WindSpeed { get; set; }
    }

    public class HourlyData
    {
        public DateTime? Time { get; set; }
        public HourlyValues? Values { get; set; }
    }

    public class HourlyValues
    {
        public double? CloudBase { get; set; }
        public double? CloudCeiling { get; set; }
        public double? CloudCover { get; set; }
        public double? DewPoint { get; set; }
        public double? Evapotranspiration { get; set; }
        public double? FreezeRainIntensity { get; set; }
        public double? Humidity { get; set; }
        public double? IceAccumulation { get; set; }
        public double? IceAccumulationLwe { get; set; }
        public double? PrecipitationProbability { get; set; }
        public double? PressureSurfaceLevel { get; set; }
        public double? RainAccumulation { get; set; }
        public double? RainAccumulationLwe { get; set; }
        public double? RainIntensity { get; set; }
        public double? SleetAccumulation { get; set; }
        public double? SleetAccumulationLwe { get; set; }
        public double? SleetIntensity { get; set; }
        public double? SnowAccumulation { get; set; }
        public double? SnowAccumulationLwe { get; set; }
        public double? SnowDepth { get; set; }
        public double? SnowIntensity { get; set; }
        public double? Temperature { get; set; }
        public double? TemperatureApparent { get; set; }
        public double? UvHealthConcern { get; set; }
        public double? UvIndex { get; set; }
        public double? Visibility { get; set; }
        public int? WeatherCode { get; set; }
        public double? WindDirection { get; set; }
        public double? WindGust { get; set; }
        public double? WindSpeed { get; set; }
    }

    public class DailyData
    {
        public DateTime? Time { get; set; }
        public DailyValues? Values { get; set; }
    }

    public class DailyValues
    {
        public double? CloudBaseAvg { get; set; }
        public double? CloudBaseMax { get; set; }
        public double? CloudBaseMin { get; set; }
        public double? CloudCeilingAvg { get; set; }
        public double? CloudCeilingMax { get; set; }
        public double? CloudCeilingMin { get; set; }
        public double? CloudCoverAvg { get; set; }
        public double? CloudCoverMax { get; set; }
        public double? CloudCoverMin { get; set; }
        public double? DewPointAvg { get; set; }
        public double? DewPointMax { get; set; }
        public double? DewPointMin { get; set; }
        public double? EvapotranspirationAvg { get; set; }
        public double? EvapotranspirationMax { get; set; }
        public double? EvapotranspirationMin { get; set; }
        public double? EvapotranspirationSum { get; set; }
        public double? FreezeRainIntensityAvg { get; set; }
        public double? FreezeRainIntensityMax { get; set; }
        public double? FreezeRainIntensityMin { get; set; }
        public double? HumidityAvg { get; set; }
        public double? HumidityMax { get; set; }
        public double? HumidityMin { get; set; }
        public double? IceAccumulationAvg { get; set; }
        public double? IceAccumulationLweAvg { get; set; }
        public double? IceAccumulationLweMax { get; set; }
        public double? IceAccumulationLweMin { get; set; }
        public double? IceAccumulationLweSum { get; set; }
        public double? IceAccumulationMax { get; set; }
        public double? IceAccumulationMin { get; set; }
        public double? IceAccumulationSum { get; set; }
        public DateTime? MoonriseTime { get; set; }
        public DateTime? MoonsetTime { get; set; }
        public double? PrecipitationProbabilityAvg { get; set; }
        public double? PrecipitationProbabilityMax { get; set; }
        public double? PrecipitationProbabilityMin { get; set; }
        public double? PressureSurfaceLevelAvg { get; set; }
        public double? PressureSurfaceLevelMax { get; set; }
        public double? PressureSurfaceLevelMin { get; set; }
        public double? RainAccumulationAvg { get; set; }
        public double? RainAccumulationLweAvg { get; set; }
        public double? RainAccumulationLweMax { get; set; }
        public double? RainAccumulationLweMin { get; set; }
        public double? RainAccumulationMax { get; set; }
        public double? RainAccumulationMin { get; set; }
        public double? RainAccumulationSum { get; set; }
        public double? RainIntensityAvg { get; set; }
        public double? RainIntensityMax { get; set; }
        public double? RainIntensityMin { get; set; }
        public double? SleetAccumulationAvg { get; set; }
        public double? SleetAccumulationLweAvg { get; set; }
        public double? SleetAccumulationLweMax { get; set; }
        public double? SleetAccumulationLweMin { get; set; }
        public double? SleetAccumulationLweSum { get; set; }
        public double? SleetAccumulationMax { get; set; }
        public double? SleetAccumulationMin { get; set; }
        public double? SleetIntensityAvg { get; set; }
        public double? SleetIntensityMax { get; set; }
        public double? SleetIntensityMin { get; set; }
        public double? SnowAccumulationAvg { get; set; }
        public double? SnowAccumulationLweAvg { get; set; }
        public double? SnowAccumulationLweMax { get; set; }
        public double? SnowAccumulationLweMin { get; set; }
        public double? SnowAccumulationLweSum { get; set; }
        public double? SnowAccumulationMax { get; set; }
        public double? SnowAccumulationMin { get; set; }
        public double? SnowAccumulationSum { get; set; }
        public double? SnowDepthAvg { get; set; }
        public double? SnowDepthMax { get; set; }
        public double? SnowDepthMin { get; set; }
        public double? SnowDepthSum { get; set; }
        public double? SnowIntensityAvg { get; set; }
        public double? SnowIntensityMax { get; set; }
        public double? SnowIntensityMin { get; set; }
        public DateTime? SunriseTime { get; set; }
        public DateTime? SunsetTime { get; set; }
        public double? TemperatureApparentAvg { get; set; }
        public double? TemperatureApparentMax { get; set; }
        public double? TemperatureApparentMin { get; set; }
        public double? TemperatureAvg { get; set; }
        public double? TemperatureMax { get; set; }
        public double? TemperatureMin { get; set; }
        public double? UvHealthConcernAvg { get; set; }
        public double? UvHealthConcernMax { get; set; }
        public double? UvHealthConcernMin { get; set; }
        public double? UvIndexAvg { get; set; }
        public double? UvIndexMax { get; set; }
        public double? UvIndexMin { get; set; }
        public double? VisibilityAvg { get; set; }
        public double? VisibilityMax { get; set; }
        public double? VisibilityMin { get; set; }
        public int? WeatherCodeMax { get; set; }
        public int? WeatherCodeMin { get; set; }
        public double? WindDirectionAvg { get; set; }
        public double? WindGustAvg { get; set; }
        public double? WindGustMax { get; set; }
        public double? WindGustMin { get; set; }
        public double? WindSpeedAvg { get; set; }
        public double? WindSpeedMax { get; set; }
        public double? WindSpeedMin { get; set; }
    }
}
