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
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDal;

        public SurveyController(ISurveyDAL surveyDal)
        {
            this.surveyDal = surveyDal;
        }

        [HttpGet]
        public ActionResult Submit()
        {
            return View("Submit");
        }

        [HttpPost]
        public ActionResult Submit(SurveyModel newSurvey)
        {

            surveyDal.SaveSurvey(newSurvey);

          return RedirectToAction("SurveyResult");
        }
    }
}