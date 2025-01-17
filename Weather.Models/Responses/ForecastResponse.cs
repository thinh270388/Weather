namespace Weather.Models.Responses
{
    public class ForecastResponse
    {
        public double? Temp { get; set; }
        public double? Temp_Min { get; set; }
        public double? Temp_Max { get; set; }
        public double? FeelLike { get; set; }
        public double? Pressure { get; set; }
        public double? Humidity { get; set; }
        public double? WindSpeed { get; set; }
        public string? Dt_Txt { get; set; }
        public string? Time { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
    }
}
