namespace Weather.Models
{
    public class LocalWeather
    {
        public string? DiaDiemDuBao { get; set; }
        public List<CurrentLocal>? Currents { get; set; }
    }
    public class CurrentLocal
    {
        public string? ThoiGian { get; set; }
        public int? Tm { get; set; }
        public int? Tx { get; set; }
        public int? R { get; set; }
        public int? XacSuatMua { get; set; }
        public string? HuongGio { get; set; }
        public int? TocDoGio { get; set; }
        public int? DoAm { get; set; }
        public int? ThoiTiet { get; set; }
    }
}
