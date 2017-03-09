using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;
using System.Configuration;

namespace Capstone.Web.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherDAL weatherDal;

        public WeatherController(IWeatherDAL weatherDal)
        {
            this.weatherDal = weatherDal;
        }

        //GET: Home

        public ActionResult Weather(string id, char unit)
        {
            return View("Weather", weatherDal.GetWeather(id, unit));
        }
    }
}