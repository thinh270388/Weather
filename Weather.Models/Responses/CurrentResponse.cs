namespace Weather.Models.Responses
{
    public class CurrentResponse
    {
        public string? City { get; set; } = string.Empty;
        public string? Nation { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
        public string? Coordinates { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? Icon { get; set; } = string.Empty;
        public double? Temperature { get; set; }
        public double? Pressure { get; set; }
        public int? Humidity { get; set; }
        public double? WindSpeed { get; set; }
        public string? WindDirection { get; set; } = string.Empty;
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; } = string.Empty;
        public int? PrecipitationProbability { get; set; }
        public double? RainIntensity { get; set; }
    }
}
