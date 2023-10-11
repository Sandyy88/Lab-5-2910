using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_2910
{
    public class Coordinates
    {
        public string Latitude {  get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;

        public Coordinates() { }
        public Coordinates(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
