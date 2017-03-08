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
            return View("Index", parkDal.GetAllParks());
        }
    }
}