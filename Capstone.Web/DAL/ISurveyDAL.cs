using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAL
    {
        bool SaveSurvey(SurveyModel newSurvey);
        SurveyModel GetSurvey();
    }
}