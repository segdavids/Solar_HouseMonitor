using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace solar_monitor.Models
{
    public class weather
    {
        public class response
        {
            public double lat { get; set; }
            public double lon { get; set; }
            public string timezone { get; set; }
            public int timezone_offset { get; set; }
            public currentobj current { get; set; }
            public List<dailyobj> daily { get; set; }
        }
        public class currentobj
        {
            public int dt { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
            public double dew_point { get; set; }
            public double uvi { get; set; }
            public int clouds { get; set; }
            public int visibility { get; set; }
            public double wind_speed { get; set; }
            public int wind_deg { get; set; }
            public double wind_gust { get; set; }
            public List<weatherobj> weather { get; set; }
            public rainobj rain { get; set; }
        }
        public class dailyobj
        {
            public int dt { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
            public int moonrise { get; set; }
            public int moonset { get; set; }
            public double moon_phase { get; set; }
            public tempobj temp { get; set; }
            public feels_likeobj feels_like { get; set; }
            public double pressure { get; set; }
            public int humidity { get; set; }
            public double dew_point { get; set; }
            public double wind_speed { get; set; }
            public int wind_deg { get; set; }
            public double wind_gust { get; set; }
            public List<weatherobj> weather { get; set; }
            public int clouds { get; set; }
            public double pop { get; set; }
            public double rain { get; set; }
            public double uvi { get; set; }
        }
        public class rainobj
        {
            public double h { get; set; }
        }
        public class weatherobj
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class feels_likeobj
        {
            public double day { get; set; }
            public double night { get; set; }
            public double eve { get; set; }
            public double morn { get; set; }
        }
        public class tempobj
        {
            public double day { get; set; }
            public double min { get; set; }
            public double max { get; set; }
            public double night { get; set; }
            public double eve { get; set; }
            public double morn { get; set; }
        }
    }
}