using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class WeatherDayModel
    {
        public string ParkCode { get; set; }

        public string Day { get; set; }

        public int High { get; set; }

        public int Low { get; set; }

        public string Forecast { get; set; }

        public double ConvertC(int tempInF)
        {
            double result;

            result = ((double)tempInF - 32) * (5 / 9);

            return result;
        }

    }

}
