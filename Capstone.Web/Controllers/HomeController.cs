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
    public class HomeController : Controller
    {
        private IParkListDAL parkDal;

        public HomeController(IParkListDAL parkDal)
        {
            this.parkDal = parkDal;
        }

        //GET: Home

        public ActionResult Index()
        {
            if (Session["whatUnit"] == null)
            {
                Session["whatUnit"] = new WeatherDayModel();
            }

            return View("Index", parkDal.GetAllParks());
        }

        public ActionResult ParkDetail(string id)
        {       
            return View("ParkDetail", parkDal.GetPark(id));
        }
    }
}