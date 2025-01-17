using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models.DTOs
{
    public class TimeGroup
    {
        public string? TimeInfo { get; set; }
        public List<Place>? Places { get; set; }
    }

    public class Place
    {
        public string? Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
