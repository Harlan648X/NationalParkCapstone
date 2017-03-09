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

        public char Unit { get; set; }

        public double ConvertC(int tempInF)
        {
            double result;

            result = Math.Round(((double)tempInF - 32.00) * (5.00 / 9.00), 2);

            return result;
        }

    }

}
