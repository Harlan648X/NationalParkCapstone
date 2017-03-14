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
        {//if no session exists create one and set the initial unit to F

            if (Session["whatUnit"] == null)
            {
                Session["whatUnit"] = new ParkListModel(); //session ["whatUnit"] = 'f'
                ParkListModel existingSession = Session["whatUnit"] as ParkListModel;
                existingSession.Unit = 'F'; 
            }
            return View("Index", parkDal.GetAllParks());
        }

        public ActionResult ParkDetail(string id)
        {//create an object from session and use its Unit property to pass to the GetPark method of ParkListSqlDAL
            ParkListModel existingSession = Session["whatUnit"] as ParkListModel;
            // char whatUnit = Session["whatUnit] as char;

            return View("ParkDetail", parkDal.GetPark(id, existingSession.Unit));
        }                             //parkDal.GetPark(id, whatUnit);
    }
}