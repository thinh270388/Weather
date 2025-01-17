namespace Weather.Models.DTOs
{
    public class LocationButton
    {
        public string? Name { get; set; }
        public List<SubLocation>? SubLocations { get; set; }
    }
    public class SubLocation
    {
        public string? SubName { get; set; }
        public string? Link { get; set; }
    }
}
