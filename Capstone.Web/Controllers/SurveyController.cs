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

            if (!ModelState.IsValid)
            {
                return View("Submit");
            }

            surveyDal.SaveSurvey(newSurvey);


            return RedirectToAction("SurveyResult");
        }

        public ActionResult SurveyResult()
        {
            return View("SurveyResult", surveyDal.GetSurvey());
        }
    }
}