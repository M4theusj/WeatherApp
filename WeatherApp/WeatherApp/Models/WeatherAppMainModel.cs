using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherAppMainModel
    {
        public List<WeatherModel> weather { get; set; }
        public MainModel main { get; set; }
        public WindModel wind { get; set; }
        public CloudsModel clouds { get; set; }
        public SysModel sys { get; set; }
        public CoordModel coord { get; set; }
        public RainModel rain { get; set; } 
        public string @base { get; set; }
        public int visibility { get; set; }
        public int dt { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
