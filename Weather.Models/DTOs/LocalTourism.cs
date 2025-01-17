namespace Weather.Models.DTOs
{
    public class LocalTourism
    {
        public string? PlaceLocal { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public List<string>? Images { get; set; }
        public string? Infomation { get; set; }
        public string? Time { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Website { get; set; }
        public string? Utility { get; set; }
        public string? Price { get; set; }
        public decimal? Point { get; set; }
        public List<string>? Comments { get; set; }
        public string? Coordinates { get; set; }
        public double? Distance { get; set; }
        public double? DistanceDriving { get; set; }
        public string? TimeDriving { get; set; }
    }
    public class HereAPI
    {
        public double? DistanceDriving { get; set; }
        public string? TimeDriving { get; set; }
    }
}
