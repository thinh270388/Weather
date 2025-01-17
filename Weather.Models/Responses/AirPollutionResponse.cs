namespace Weather.Models.Responses
{
    public class AirPollutionResponse
    {
        public string AirQuality { get; set; } = "Chưa xác định";
        public double SO2 { get; set; }
        public double NO2 { get; set; }
        public double PM10 { get; set; }
        public double PM25 { get; set; }
        public double O3 { get; set; }
        public double CO { get; set; }
    }
}
