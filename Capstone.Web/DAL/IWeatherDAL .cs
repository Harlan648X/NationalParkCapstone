using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IWeatherDAL
    {
        List<WeatherDayModel> GetWeather(string id, char unit);
    }
}