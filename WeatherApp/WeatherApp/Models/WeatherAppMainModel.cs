using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherAppMainModel
    {
        public List<WeatherModel> weather;
        public MainModel main;
        public WindModel wind;
        public CloudsModel cloud;
        public SysModel sys;
        public CoordModel coord;
        public string @base;
        public int visibility;
        public int dt;
        public int timezone;
        public int id;
        public string name;
        public int cod;
    }
}
